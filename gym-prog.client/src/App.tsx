import { Routes, Route, Link } from 'react-router-dom';
import WorkoutsList from './components/WorkoutsList';
import AddWorkout from './components/AddWorkout';
import Navbar from './components/Navbar';

function App() {
    return (
        <div className="min-h-screen bg-gray-50">
            <Navbar />
            <div className="container mx-auto px-4 py-8">
                <Routes>
                    <Route path="/" element={<WorkoutsList />} />
                    <Route path="/add-workout" element={<AddWorkout />} />
                </Routes>
            </div>
        </div>
    );
}

export default App;
