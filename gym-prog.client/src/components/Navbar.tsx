import { Link } from 'react-router-dom';

const Navbar = () => {
    return (
        <nav className="bg-blue-600 text-white shadow-lg">
            <div className="container mx-auto px-4 py-3">
                <div className="flex justify-between items-center">
                    <Link to="/" className="text-xl font-bold">
                        AI Gym Coach
                    </Link>
                    <div className="flex space-x-4">
                        <Link to="/" className="px-3 py-2 hover:text-blue-200">
                            Home
                        </Link>
                        <Link to="/dashboard" className="px-3 py-2 hover:text-blue-200">
                            Dashboard
                        </Link>
                        <Link to="/add-workout" className="px-3 py-2 hover:text-blue-200">
                            Add Workout
                        </Link>
                    </div>
                </div>
            </div>
        </nav>
    );
};

export default Navbar;
