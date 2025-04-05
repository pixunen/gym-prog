import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Exercise } from '../types';

interface WorkoutFormData {
    name: string;
    description: string;
    date: string;
    exercises: Exercise[];
}

const AddWorkout = () => {
    const navigate = useNavigate();
    const [formData, setFormData] = useState<WorkoutFormData>({
        name: '',
        description: '',
        date: new Date().toISOString().split('T')[0],
        exercises: []
    });

    const [currentExercise, setCurrentExercise] = useState<Omit<Exercise, 'id'>>({
        name: '',
        description: '',
        sets: 3,
        reps: 10
    });

    const [error, setError] = useState('');

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value } = e.target;
        setFormData(prev => ({
            ...prev,
            [name]: value
        }));
    };

    const handleExerciseChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value } = e.target;
        setCurrentExercise(prev => ({
            ...prev,
            [name]: name === 'sets' || name === 'reps' ? parseInt(value) || 0 : value
        }));
    };

    const addExercise = () => {
        if (!currentExercise.name) {
            setError('Exercise name is required');
            return;
        }

        setFormData(prev => ({
            ...prev,
            exercises: [
                ...prev.exercises,
                {
                    ...currentExercise,
                    id: crypto.randomUUID()
                }
            ]
        }));

        setCurrentExercise({
            name: '',
            description: '',
            sets: 3,
            reps: 10
        });

        setError('');
    };

    const removeExercise = (id: string) => {
        setFormData(prev => ({
            ...prev,
            exercises: prev.exercises.filter(exercise => exercise.id !== id)
        }));
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        if (!formData.name) {
            setError('Workout name is required');
            return;
        }

        if (formData.exercises.length === 0) {
            setError('Add at least one exercise to the workout');
            return;
        }

        try {
            const response = await fetch('api/workout', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(formData)
            });

            if (response.ok) {
                navigate('/');
            } else {
                const errorData = await response.json();
                setError(errorData.message || 'Failed to create workout');
            }
        } catch (error) {
            console.error('Error creating workout:', error);
            setError('An error occurred while creating the workout');
        }
    };

    return (
        <div className="max-w-3xl mx-auto">
            <h1 className="text-3xl font-bold text-gray-800 mb-6 text-center">Create New Workout</h1>

            {error && (
                <div className="bg-red-100 border border-red-400 text-red-700 px-4 py-3 rounded mb-4">
                    {error}
                </div>
            )}

            <form onSubmit={handleSubmit} className="bg-white shadow-md rounded-lg p-6 mb-8">
                <div className="mb-6">
                    <label className="block text-gray-700 font-semibold mb-2" htmlFor="name">
                        Workout Name *
                    </label>
                    <input
                        type="text"
                        id="name"
                        name="name"
                        value={formData.name}
                        onChange={handleChange}
                        className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                        placeholder="Push Day, Leg Day, etc."
                    />
                </div>

                <div className="mb-6">
                    <label className="block text-gray-700 font-semibold mb-2" htmlFor="description">
                        Description
                    </label>
                    <textarea
                        id="description"
                        name="description"
                        value={formData.description}
                        onChange={handleChange}
                        className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                        rows={3}
                        placeholder="Describe your workout..."
                    />
                </div>

                <div className="mb-6">
                    <label className="block text-gray-700 font-semibold mb-2" htmlFor="date">
                        Date
                    </label>
                    <input
                        type="date"
                        id="date"
                        name="date"
                        value={formData.date}
                        onChange={handleChange}
                        className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                    />
                </div>

                <div className="mb-8">
                    <h3 className="text-xl font-semibold text-gray-800 mb-4">Exercises</h3>

                    {formData.exercises.length > 0 ? (
                        <div className="space-y-3 mb-6">
                            {formData.exercises.map((exercise) => (
                                <div key={exercise.id} className="flex items-center bg-gray-50 p-3 rounded">
                                    <div className="flex-grow">
                                        <h4 className="font-medium">{exercise.name}</h4>
                                        <div className="flex text-sm text-gray-600">
                                            <span className="mr-4">{exercise.sets} sets × {exercise.reps} reps</span>
                                            {exercise.description && <span>• {exercise.description}</span>}
                                        </div>
                                    </div>
                                    <button
                                        type="button"
                                        onClick={() => removeExercise(exercise.id)}
                                        className="text-red-500 hover:text-red-700"
                                    >
                                        <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16" />
                                        </svg>
                                    </button>
                                </div>
                            ))}
                        </div>
                    ) : (
                        <p className="text-gray-500 mb-4">No exercises added yet.</p>
                    )}

                    <div className="bg-gray-50 p-4 rounded-md">
                        <h4 className="font-medium mb-3">Add Exercise</h4>
                        <div className="space-y-3">
                            <div>
                                <label className="block text-sm font-medium text-gray-700 mb-1" htmlFor="exerciseName">
                                    Exercise Name *
                                </label>
                                <input
                                    type="text"
                                    id="exerciseName"
                                    name="name"
                                    value={currentExercise.name}
                                    onChange={handleExerciseChange}
                                    className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                                    placeholder="Bench Press, Squat, etc."
                                />
                            </div>

                            <div className="flex gap-4">
                                <div className="w-1/2">
                                    <label className="block text-sm font-medium text-gray-700 mb-1" htmlFor="exerciseSets">
                                        Sets
                                    </label>
                                    <input
                                        type="number"
                                        id="exerciseSets"
                                        name="sets"
                                        value={currentExercise.sets}
                                        onChange={handleExerciseChange}
                                        min="1"
                                        className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                                    />
                                </div>

                                <div className="w-1/2">
                                    <label className="block text-sm font-medium text-gray-700 mb-1" htmlFor="exerciseReps">
                                        Reps
                                    </label>
                                    <input
                                        type="number"
                                        id="exerciseReps"
                                        name="reps"
                                        value={currentExercise.reps}
                                        onChange={handleExerciseChange}
                                        min="1"
                                        className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                                    />
                                </div>
                            </div>

                            <div>
                                <label className="block text-sm font-medium text-gray-700 mb-1" htmlFor="exerciseDescription">
                                    Description (optional)
                                </label>
                                <input
                                    type="text"
                                    id="exerciseDescription"
                                    name="description"
                                    value={currentExercise.description}
                                    onChange={handleExerciseChange}
                                    className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                                    placeholder="Notes, weights, etc."
                                />
                            </div>

                            <button
                                type="button"
                                onClick={addExercise}
                                className="w-full bg-blue-500 hover:bg-blue-600 text-white font-medium py-2 px-4 rounded focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-opacity-50"
                            >
                                Add Exercise
                            </button>
                        </div>
                    </div>
                </div>

                <div className="flex gap-4">
                    <button
                        type="button"
                        onClick={() => navigate('/')}
                        className="w-1/3 bg-gray-200 hover:bg-gray-300 text-gray-800 font-medium py-2 px-4 rounded focus:outline-none focus:ring-2 focus:ring-gray-500 focus:ring-opacity-50"
                    >
                        Cancel
                    </button>
                    <button
                        type="submit"
                        className="w-2/3 bg-blue-600 hover:bg-blue-700 text-white font-medium py-2 px-4 rounded focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-opacity-50"
                    >
                        Save Workout
                    </button>
                </div>
            </form>
        </div>
    );
};

export default AddWorkout;
