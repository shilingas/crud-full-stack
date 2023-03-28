import React from 'react';
import { Link } from 'react-router-dom';
import Cart from './Cart';
import Input from './Input';
const HomePage = () => {
    return (
        <div>
            <p>home page...</p>
            <Link to="/input">
                To input functionality
            </Link>
            <br />
            <Link to="/cart">
                To cart functionality
            </Link>
        </div>
    );
}
export default HomePage;