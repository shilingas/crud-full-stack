import logo from './logo.svg';
import './App.css';
import Input from './Input';
import Navbar from './Navbar';
import { Routes, Route, BrowserRouter } from "react-router-dom";
import HomePage from "./HomePage";
import Cart from "./Cart";
import People from "./People";
import PersonManager from './PersonManager';
import FileUpload from "../src/FileUpload";
import TodoList from "../src/TodoList";
function App() {
    return (
        <div className="App">
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/input" element={<Input />} />
                    <Route path="/cart" element={<Cart />} />
                    <Route path="/people" element={<People />} />
                    <Route path="/manager" element={<PersonManager />} />
                    <Route path="/file-upload" element={<FileUpload />} />
                    <Route path="/todo-list" element={<TodoList />} />
                </Routes>
            </BrowserRouter>
        </div>
    );
}

export default App;
