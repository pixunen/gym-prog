import { useState, useEffect } from 'react';
import {
    BarChart, Bar, LineChart, Line, XAxis, YAxis, CartesianGrid,
    Tooltip, Legend, ResponsiveContainer
} from 'recharts';

// Types
interface Exercise {
    id: string;
    name: string;
    description: string;
    sets: number;
    reps: number;
    weight: number;
}

interface Workout {
    id: string;
    name: string;
    description: string;
    date: string;
    exercises: Exercise[];
}

interface ExerciseProgress {
    date: string;
    name: string;
    weight: number;
    sets: number;
    reps: number;
    volume: number;
}

interface AIPrediction {
    exerciseName: string;
    predictedSets: number;
    predictedReps: number;
    predictedWeight: number;
    isModelPrediction: boolean;
    message?: string;
}

interface ModelStatus {
    modelTrained: boolean;
    onnxExported: boolean;
    lastTrainedUtc: string | null;
}

const WorkoutDashboard = () => {
    const [workouts, setWorkouts] = useState<Workout[]>([]);
    const [exerciseProgress, setExerciseProgress] = useState<ExerciseProgress[]>([]);
    const [predictions, setPredictions] = useState<AIPrediction[]>([]);
    const [selectedExercise, setSelectedExercise] = useState<string>('');
    const [uniqueExercises, setUniqueExercises] = useState<string[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);
    const [modelStatus, setModelStatus] = useState<ModelStatus | null>(null);

    // Fetch workouts data
    useEffect(() => {
        const fetchWorkouts = async () => {
            try {
                // Fetch model status first
                await fetchModelStatus();

                const response = await fetch('api/workout');
                if (!response.ok) {
                    throw new Error('Failed to fetch workouts');
                }
                const data = await response.json();
                setWorkouts(data);

                // Extract unique exercise names
                const exerciseSet = new Set<string>();
                const progressData: ExerciseProgress[] = [];

                data.forEach((workout: Workout) => {
                    workout.exercises.forEach((exercise: Exercise) => {
                        exerciseSet.add(exercise.name);

                        // Calculate volume (sets * reps * weight)
                        const volume = exercise.sets * exercise.reps * (exercise.weight || 1);

                        progressData.push({
                            date: new Date(workout.date).toLocaleDateString(),
                            name: exercise.name,
                            weight: exercise.weight,
                            sets: exercise.sets,
                            reps: exercise.reps,
                            volume
                        });
                    });
                });

                setUniqueExercises(Array.from(exerciseSet).sort());
                setExerciseProgress(progressData);

                if (exerciseSet.size > 0) {
                    setSelectedExercise(Array.from(exerciseSet)[0]);
                    // Request prediction for the first exercise
                    requestPrediction(Array.from(exerciseSet)[0]);
                }
            } catch (err) {
                setError(err instanceof Error ? err.message : 'An unknown error occurred');
                console.error('Error fetching workouts:', err);
            } finally {
                setLoading(false);
            }
        };

        fetchWorkouts();
    }, []);

    // Fetch model status
    const fetchModelStatus = async () => {
        try {
            const response = await fetch('api/ml/train-status');
            if (!response.ok) {
                throw new Error('Failed to fetch model status');
            }
            const data = await response.json();
            setModelStatus(data);
            return data;
        } catch (err) {
            console.error('Error fetching model status:', err);
            return null;
        }
    };

    // Request prediction from the ML service
    const requestPrediction = async (exerciseName: string) => {
        if (!exerciseName) return;

        try {
            // Find the most recent instance of this exercise
            const exerciseInstances = exerciseProgress
                .filter(e => e.name === exerciseName)
                .sort((a, b) => new Date(b.date).getTime() - new Date(a.date).getTime());

            if (exerciseInstances.length === 0) return;

            const latestExercise = exerciseInstances[0];
            const prevExercise = exerciseInstances.length > 1 ? exerciseInstances[1] : latestExercise;

            // Calculate days since last workout
            const daysSinceLastWorkout = Math.max(
                1,
                Math.round((new Date().getTime() - new Date(latestExercise.date).getTime()) / (1000 * 60 * 60 * 24))
            );

            // Prepare the payload for prediction
            const payload = {
                exerciseName,
                previousSets: prevExercise.sets,
                previousReps: prevExercise.reps,
                userStrengthLevel: latestExercise.weight || 1, // Use weight as proxy for strength
                daysSinceLastWorkout
            };

            // Call ML prediction endpoint
            const response = await fetch('api/ml/predict', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(payload)
            });

            if (!response.ok) {
                throw new Error('Failed to get prediction');
            }

            const prediction = await response.json();

            // Update predictions state
            setPredictions(prev => {
                const filteredPredictions = prev.filter(p => p.exerciseName !== exerciseName);
                return [
                    ...filteredPredictions,
                    {
                        exerciseName,
                        predictedSets: Math.round(prediction.predictedSets || latestExercise.sets + 1),
                        predictedReps: Math.round(prediction.predictedReps || latestExercise.reps + 1),
                        predictedWeight: prediction.predictedWeight || Math.round(latestExercise.weight * 1.05), // 5% increase if no prediction
                        isModelPrediction: prediction.isModelPrediction || false,
                        message: prediction.message || ''
                    }
                ];
            });

        } catch (err) {
            console.error('Error getting prediction:', err);
            // If prediction fails, create a simple progression
            const exerciseInstances = exerciseProgress
                .filter(e => e.name === exerciseName)
                .sort((a, b) => new Date(b.date).getTime() - new Date(a.date).getTime());

            if (exerciseInstances.length > 0) {
                const latest = exerciseInstances[0];
                setPredictions(prev => {
                    const filteredPredictions = prev.filter(p => p.exerciseName !== exerciseName);
                    return [
                        ...filteredPredictions,
                        {
                            exerciseName,
                            predictedSets: latest.sets + 1,
                            predictedReps: latest.reps + 1,
                            predictedWeight: Math.round(latest.weight * 1.05), // 5% increase
                            isModelPrediction: false,
                            message: 'Error getting prediction. Using simple progression.'
                        }
                    ];
                });
            }
        }
    };

    const handleExerciseChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
        const newExercise = e.target.value;
        setSelectedExercise(newExercise);
        requestPrediction(newExercise);
    };

    // Filter the progress data for the selected exercise
    const filteredProgressData = exerciseProgress
        .filter(item => item.name === selectedExercise)
        .sort((a, b) => new Date(a.date).getTime() - new Date(b.date).getTime());

    // Find the current prediction for the selected exercise
    const currentPrediction = predictions.find(p => p.exerciseName === selectedExercise);

    // Get the latest performance data
    const latestExerciseData = filteredProgressData.length > 0
        ? filteredProgressData[filteredProgressData.length - 1]
        : null;

    // Calculate statistics
    const calculateStats = () => {
        if (!selectedExercise || filteredProgressData.length === 0) {
            return { maxWeight: 0, maxVolume: 0, improvement: 0 };
        }

        const maxWeight = Math.max(...filteredProgressData.map(d => d.weight));
        const maxVolume = Math.max(...filteredProgressData.map(d => d.volume));

        // Calculate improvement percentage if we have at least two entries
        let improvement = 0;
        if (filteredProgressData.length >= 2) {
            const firstEntry = filteredProgressData[0];
            const lastEntry = filteredProgressData[filteredProgressData.length - 1];
            improvement = ((lastEntry.volume - firstEntry.volume) / firstEntry.volume) * 100;
        }

        return { maxWeight, maxVolume, improvement };
    };

    const stats = calculateStats();

    // Navigation function (would normally use a router)
    const navigateToAddWorkout = () => {
        window.location.href = '/add-workout';
    };

    // Function to trigger manual model training
    const triggerModelTraining = async () => {
        try {
            setLoading(true);
            const response = await fetch('api/ml/train', {
                method: 'POST'
            });

            if (!response.ok) {
                throw new Error('Failed to train model');
            }

            await fetchModelStatus();
            alert('Model training completed successfully!');
        } catch (err) {
            console.error('Error training model:', err);
            setError('Failed to train model. Please try again later.');
        } finally {
            setLoading(false);
        }
    };

    if (loading) {
        return (
            <div className="flex justify-center items-center h-64">
                <div className="animate-spin rounded-full h-12 w-12 border-t-2 border-b-2 border-blue-500"></div>
            </div>
        );
    }

    if (error) {
        return (
            <div className="bg-red-100 border border-red-400 text-red-700 px-4 py-3 rounded mb-4">
                <p className="font-bold">Error loading dashboard</p>
                <p>{error}</p>
            </div>
        );
    }

    return (
        <div className="max-w-6xl mx-auto px-4 py-8">
            <h1 className="text-3xl font-bold text-gray-800 mb-6 text-center">Workout Progress Dashboard</h1>

            {workouts.length === 0 ? (
                <div className="text-center p-8 bg-white rounded-lg shadow">
                    <p className="text-gray-600 mb-4">No workout data found. Start tracking your workouts to see progress!</p>
                    <button
                        onClick={navigateToAddWorkout}
                        className="bg-blue-600 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded"
                    >
                        Add Your First Workout
                    </button>
                </div>
            ) : (
                <div className="space-y-8">
                    {/* Model Status Card */}
                    <div className="bg-white rounded-lg shadow-md p-6">
                        <h3 className="text-lg font-medium text-gray-800 mb-4">AI Model Status</h3>
                        <div className="flex flex-col md:flex-row justify-between items-center">
                            <div className="mb-4 md:mb-0">
                                <div className="flex items-center mb-2">
                                    <div className={`h-3 w-3 rounded-full mr-2 ${modelStatus?.modelTrained ? 'bg-green-500' : 'bg-red-500'}`}></div>
                                    <p className="text-sm">Model trained: {modelStatus?.modelTrained ? 'Yes' : 'No'}</p>
                                </div>
                                {modelStatus?.lastTrainedUtc && (
                                    <p className="text-xs text-gray-600">Last trained: {new Date(modelStatus.lastTrainedUtc).toLocaleString()}</p>
                                )}
                            </div>
                            <button
                                onClick={triggerModelTraining}
                                className="bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded text-sm"
                                disabled={loading}
                            >
                                Train Model Now
                            </button>
                        </div>
                    </div>

                    <div className="bg-white rounded-lg shadow-md p-6">
                        <div className="flex flex-col md:flex-row md:justify-between md:items-center mb-6">
                            <h2 className="text-xl font-semibold text-gray-800 mb-4 md:mb-0">Exercise Progress Tracker</h2>
                            <div className="w-full md:w-64">
                                <select
                                    value={selectedExercise}
                                    onChange={handleExerciseChange}
                                    className="w-full p-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                                >
                                    {uniqueExercises.map(exercise => (
                                        <option key={exercise} value={exercise}>
                                            {exercise}
                                        </option>
                                    ))}
                                </select>
                            </div>
                        </div>

                        {filteredProgressData.length === 0 ? (
                            <p className="text-center text-gray-600 my-8">No data available for {selectedExercise}</p>
                        ) : (
                            <div className="h-72">
                                <ResponsiveContainer width="100%" height="100%">
                                    <LineChart
                                        data={filteredProgressData}
                                        margin={{ top: 5, right: 30, left: 20, bottom: 5 }}
                                    >
                                        <CartesianGrid strokeDasharray="3 3" />
                                        <XAxis dataKey="date" />
                                        <YAxis yAxisId="left" />
                                        <YAxis yAxisId="right" orientation="right" />
                                        <Tooltip />
                                        <Legend />
                                        <Line
                                            yAxisId="left"
                                            type="monotone"
                                            dataKey="weight"
                                            stroke="#8884d8"
                                            name="Weight (kg)"
                                            activeDot={{ r: 8 }}
                                        />
                                        <Line
                                            yAxisId="right"
                                            type="monotone"
                                            dataKey="volume"
                                            stroke="#82ca9d"
                                            name="Volume (sets × reps × weight)"
                                        />
                                    </LineChart>
                                </ResponsiveContainer>
                            </div>
                        )}
                    </div>

                    <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
                        <div className="bg-white rounded-lg shadow-md p-6">
                            <h3 className="text-lg font-medium text-gray-800 mb-4">Exercise Stats</h3>
                            <div className="space-y-4">
                                <div>
                                    <p className="text-sm text-gray-600">Max Weight</p>
                                    <p className="text-2xl font-bold text-blue-600">{stats.maxWeight} kg</p>
                                </div>
                                <div>
                                    <p className="text-sm text-gray-600">Max Volume</p>
                                    <p className="text-2xl font-bold text-green-600">{stats.maxVolume.toLocaleString()}</p>
                                </div>
                                <div>
                                    <p className="text-sm text-gray-600">Progress</p>
                                    <p className={`text-2xl font-bold ${stats.improvement >= 0 ? 'text-green-600' : 'text-red-600'}`}>
                                        {stats.improvement.toFixed(1)}%
                                    </p>
                                </div>
                            </div>
                        </div>

                        <div className="bg-white rounded-lg shadow-md p-6">
                            <h3 className="text-lg font-medium text-gray-800 mb-4">Latest Performance</h3>
                            {latestExerciseData ? (
                                <div className="space-y-4">
                                    <div className="flex justify-between">
                                        <p className="text-sm text-gray-600">Date</p>
                                        <p className="text-sm font-medium">{latestExerciseData.date}</p>
                                    </div>
                                    <div className="flex justify-between">
                                        <p className="text-sm text-gray-600">Sets</p>
                                        <p className="text-lg font-medium">{latestExerciseData.sets}</p>
                                    </div>
                                    <div className="flex justify-between">
                                        <p className="text-sm text-gray-600">Reps</p>
                                        <p className="text-lg font-medium">{latestExerciseData.reps}</p>
                                    </div>
                                    <div className="flex justify-between">
                                        <p className="text-sm text-gray-600">Weight</p>
                                        <p className="text-lg font-medium">{latestExerciseData.weight} kg</p>
                                    </div>
                                </div>
                            ) : (
                                <p className="text-center text-gray-600 my-8">No data available</p>
                            )}
                        </div>

                        <div className="bg-white rounded-lg shadow-md p-6">
                            <h3 className="text-lg font-medium text-gray-800 mb-4">AI Recommendation</h3>
                            {currentPrediction ? (
                                <div className="space-y-4">
                                    <div className={`p-4 rounded-lg border ${currentPrediction.isModelPrediction ? 'bg-blue-50 border-blue-200' : 'bg-amber-50 border-amber-200'}`}>
                                        <p className="text-sm text-gray-700 mb-2">For your next <span className="font-medium">{selectedExercise}</span> session:</p>
                                        <div className="grid grid-cols-3 gap-4 mt-4">
                                            <div className="text-center">
                                                <p className="text-sm text-gray-600">Sets</p>
                                                <p className="text-2xl font-bold text-blue-600">{currentPrediction.predictedSets}</p>
                                            </div>
                                            <div className="text-center">
                                                <p className="text-sm text-gray-600">Reps</p>
                                                <p className="text-2xl font-bold text-blue-600">{currentPrediction.predictedReps}</p>
                                            </div>
                                            <div className="text-center">
                                                <p className="text-sm text-gray-600">Weight</p>
                                                <p className="text-2xl font-bold text-blue-600">{currentPrediction.predictedWeight} kg</p>
                                            </div>
                                        </div>
                                        {!currentPrediction.isModelPrediction && currentPrediction.message && (
                                            <p className="text-xs text-amber-600 mt-2 text-center">
                                                {currentPrediction.message}
                                            </p>
                                        )}
                                    </div>
                                    <div className="text-xs text-gray-500 mt-2">
                                        <p>
                                            {currentPrediction.isModelPrediction
                                                ? "This recommendation is based on AI analysis of your previous performance and progress patterns."
                                                : "This is a basic progression suggestion. Train the model for more personalized recommendations."}
                                        </p>
                                    </div>
                                </div>
                            ) : (
                                <div className="p-4 bg-yellow-50 rounded-lg border border-yellow-200">
                                    <p className="text-center text-gray-600">
                                        {selectedExercise ?
                                            `Loading recommendations for ${selectedExercise}...` :
                                            'Select an exercise to get recommendations'}
                                    </p>
                                </div>
                            )}

                            <div className="mt-6">
                                <button
                                    onClick={navigateToAddWorkout}
                                    className="block w-full bg-blue-600 hover:bg-blue-700 text-white text-center font-medium py-2 px-4 rounded transition-colors"
                                >
                                    Add New Workout
                                </button>
                            </div>
                        </div>
                    </div>

                    <div className="bg-white rounded-lg shadow-md p-6">
                        <h3 className="text-lg font-medium text-gray-800 mb-4">Workout Summary</h3>
                        <div className="h-72">
                            <ResponsiveContainer width="100%" height="100%">
                                <BarChart
                                    data={workouts.map(w => ({
                                        name: new Date(w.date).toLocaleDateString(),
                                        exerciseCount: w.exercises.length,
                                        totalVolume: w.exercises.reduce((sum, ex) => sum + (ex.sets * ex.reps * (ex.weight || 1)), 0)
                                    }))}
                                    margin={{ top: 5, right: 30, left: 20, bottom: 5 }}
                                >
                                    <CartesianGrid strokeDasharray="3 3" />
                                    <XAxis dataKey="name" />
                                    <YAxis />
                                    <Tooltip />
                                    <Legend />
                                    <Bar dataKey="exerciseCount" fill="#8884d8" name="Exercise Count" />
                                    <Bar dataKey="totalVolume" fill="#82ca9d" name="Total Volume" />
                                </BarChart>
                            </ResponsiveContainer>
                        </div>
                        <div className="mt-4 text-right">
                            <p className="text-sm text-gray-600">
                                Total workouts: <span className="font-medium">{workouts.length}</span>
                            </p>
                        </div>
                    </div>
                </div>
            )}
        </div>
    );
};

export default WorkoutDashboard;
