import React from 'react';
import { Link } from 'react-router-dom';
import Cart from './Cart';
import Input from './Input';
const HomePage = () => {
    return (
        <div>
            <p>home page...</p>
            <Link to="/input">
                To input functionality (crud on front - adding, updating, removing)
            </Link>
            <br />
            <Link to="/cart">
                To cart functionality(simple react hooks, fetching data from local API)
            </Link>
            <br />
            <Link to="/manager">
                To person manager (FULL-STACK)
            </Link>
            <br />
            <Link to="/file-upload">
                To file upload
            </Link>
        </div>
    );
}
export default HomePage;