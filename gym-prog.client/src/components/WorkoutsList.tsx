import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { Workout } from '../types';

const WorkoutsList = () => {
    const [workouts, setWorkouts] = useState<Workout[]>([]);
    const [loading, setLoading] = useState(true);
    const [expandedWorkout, setExpandedWorkout] = useState<string | null>(null);

    useEffect(() => {
        populateWorkouts();
    }, []);

    async function populateWorkouts() {
        try {
            const response = await fetch('api/workout');
            if (response.ok) {
                const data = await response.json();
                setWorkouts(data);
            } else {
                console.error('Failed to fetch workouts');
            }
        } catch (error) {
            console.error('Error fetching workouts:', error);
        } finally {
            setLoading(false);
        }
    }

    const toggleExpandWorkout = (id: string) => {
        if (expandedWorkout === id) {
            setExpandedWorkout(null);
        } else {
            setExpandedWorkout(id);
        }
    };

    if (loading) {
        return (
            <div className="flex justify-center items-center h-64">
                <div className="animate-spin rounded-full h-12 w-12 border-t-2 border-b-2 border-blue-500"></div>
            </div>
        );
    }

    return (
        <div className="space-y-6">
            <div className="flex flex-col items-center mb-10">
                <h1 className="text-3xl font-bold text-gray-800 mb-6">My Workouts</h1>
                <Link
                    to="/add-workout"
                    className="bg-blue-600 hover:bg-blue-700 text-white font-bold py-4 px-8 rounded-lg shadow-lg transition-all duration-200 transform hover:scale-105 text-xl"
                >
                    + Add Workout
                </Link>
            </div>

            {workouts.length === 0 ? (
                <div className="text-center p-8 bg-white rounded-lg shadow">
                    <p className="text-gray-600">No workouts found. Create your first workout!</p>
                </div>
            ) : (
                <div className="space-y-4">
                    {workouts.map((workout) => (
                        <div key={workout.id} className="bg-white rounded-lg shadow-md overflow-hidden">
                            <div
                                className="p-4 cursor-pointer flex justify-between items-center hover:bg-gray-50"
                                onClick={() => toggleExpandWorkout(workout.id)}
                            >
                                <div>
                                    <h3 className="text-xl font-semibold text-gray-800">{workout.name}</h3>
                                    <p className="text-gray-600">{new Date(workout.date).toLocaleDateString()}</p>
                                </div>
                                <div className="text-gray-400">
                                    {expandedWorkout === workout.id ? (
                                        <svg xmlns="http://www.w3.org/2000/svg" className="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M5 15l7-7 7 7" />
                                        </svg>
                                    ) : (
                                        <svg xmlns="http://www.w3.org/2000/svg" className="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M19 9l-7 7-7-7" />
                                        </svg>
                                    )}
                                </div>
                            </div>

                            {expandedWorkout === workout.id && (
                                <div className="px-4 pb-4 pt-2 border-t border-gray-100">
                                    <p className="text-gray-700 mb-4">{workout.description}</p>

                                    <h4 className="font-medium text-gray-800 mb-2">Exercises:</h4>
                                    <div className="space-y-3">
                                        {workout.exercises.length > 0 ? (
                                            workout.exercises.map((exercise) => (
                                                <div key={exercise.id} className="bg-gray-50 p-3 rounded">
                                                    <div className="flex justify-between">
                                                        <h5 className="font-medium">{exercise.name}</h5>
                                                        <span className="text-sm text-gray-600">{exercise.sets} × {exercise.reps}</span>
                                                    </div>
                                                    <p className="text-sm text-gray-600 mt-1">{exercise.description}</p>
                                                </div>
                                            ))
                                        ) : (
                                            <p className="text-gray-500 text-sm">No exercises added to this workout.</p>
                                        )}
                                    </div>
                                </div>
                            )}
                        </div>
                    ))}
                </div>
            )}
        </div>
    );
};

export default WorkoutsList;
