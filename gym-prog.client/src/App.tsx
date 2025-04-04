import { useEffect, useState } from 'react';

interface Workout {
    id: string,
    name: string,
    description: string,
    date: string,
    exercises: Exercise[]
}

type Exercise = {
    id: string,
    name: string,
    description: string,
    sets: number,
    reps: number
}

function App() {
    const [workouts, setWorkouts] = useState<Workout[]>();

    useEffect(() => {
        populateWorkouts();
    }, []);

    const contents = workouts === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Description</th>
                    <th>Date</th>
                </tr>
            </thead>
            <tbody>
                {workouts.map(workout =>
                    <tr key={workout.id}>
                        <td>{workout.name}</td>
                        <td>{workout.description}</td>
                        <td>{workout.date}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 className='text-red-500'>Workouts</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );

    async function populateWorkouts() {
        const response = await fetch('api/workout');
        if (response.ok) {
            const data = await response.json();
            setWorkouts(data);
        }
    }
}

export default App;
