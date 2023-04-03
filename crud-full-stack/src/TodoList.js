import React, { useState } from 'react';
import axios from 'axios';
const TodoList = () => {
    const [message, setMessage] = useState('');
    const [listOfMessages, setListOfMessages] = useState([]);
    const postTodo = (e) => {
        e.preventDefault();
        setMessage('');
        // endpointa veliau ikelsiu
        axios.post('/POST', message);
    }
    // endpointa veliau ikelsiu
    const getTodoLists = async () => {
        await axios.get('/GET').then(resp => {
            setListOfMessages(resp);
        })
    }
    // endpointa veliau ikelsiu
    const deleteTodo = async(id) => {
        await axios.delete(`/DELETE/${id}`);
    }
    // endpointa veliau ikelsiu
    const updateTodo = async(id) => {
        await axios.put(`/PUT/${id}`, {
            message: message,
        });
    }
    return (
        <div>
            <p>sw</p>
            <form onSubmit={postTodo}>
                <input type='text' value={message} onChange={(e) => setMessage(e.target.value)} placeholder='enter your todo...' />
                <button>submit</button>
            </form>
        </div>
    );
}
export default TodoList;