import logo from './logo.svg';
import './App.css';
import Input from './Input';
import Navbar from './Navbar';
import { Routes, Route, BrowserRouter } from "react-router-dom";
import HomePage from "./HomePage";
import Cart from "./Cart";
import People from "./People";
function App() {
    return (
        <div className="App">
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/input" element={<Input />} />
                    <Route path="/cart" element={<Cart />} />
                    <Route path="/people" element={<People />} />
                </Routes>
            </BrowserRouter>
        </div>
    );
}

export default App;
