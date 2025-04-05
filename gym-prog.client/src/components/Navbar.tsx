import { Link } from 'react-router-dom';

const Navbar = () => {
    return (
        <nav className="bg-blue-600 text-white shadow-lg">
            <div className="container mx-auto px-4 py-3">
                <div className="flex justify-between items-center">
                    <Link to="/" className="text-xl font-bold">
                        Gym Prog
                    </Link>
                    <div>
                        <Link to="/" className="px-4 py-2 hover:text-blue-200">
                            Home
                        </Link>
                    </div>
                </div>
            </div>
        </nav>
    );
};

export default Navbar;
