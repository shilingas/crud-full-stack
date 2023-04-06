import React, { useState } from 'react';
import axios from 'axios';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import InputGroup from 'react-bootstrap/InputGroup';
import { Calendar, theme } from 'antd';
import Card from 'react-bootstrap/Card';
import './TodoList.css';
const TodoList = () => {
    const [message, setMessage] = useState('');
    const [listOfTodos, setListOfTodos] = useState([]);
    const [currentDate, setCurrentDate] = useState('');
    const [fetchedData, setFetchedData] = useState([]);
    const [status, setStatus] = useState(false);
    const postTodo = (e) => {
        e.preventDefault();
        setMessage('');
        axios.post('https://localhost:7206/api/Todo', {
            message: message,
            currentDate: currentDate,
        });
    }
    useEffect(() => {
        axios.get('https://localhost:7206/api/Todo').then(resp => {
            setFetchedData(resp);
            setStatus(true);
        })
    }, []);
    // endpointa veliau ikelsiu
    const deleteTodo = async (id) => {
        await axios.delete(`https://localhost:7206/api/Todo/${id}`);
    }
    // endpointa veliau ikelsiu
    const updateTodo = async (id) => {
        await axios.put(`https://localhost:7206/api/Todo/${id}`, {
            message: message,
            currentDate: currentDate,
        });
    }
    const onPanelChange = (value) => {
        console.log(value.format('YYYY-MM-DD'));
        setCurrentDate(value.format('YYYY-MM-DD'));
    };
    const { token } = theme.useToken();
    const wrapperStyle = {
        width: 300,
        border: `1px solid ${token.colorBorderSecondary}`,
        borderRadius: token.borderRadiusLG,
    };
    return (
        <div className='container'>
            <InputGroup className="mb-3">
                <Form.Control
                    placeholder="Enter your todo..."
                    aria-label="Recipient's username"
                    aria-describedby="basic-addon2"
                />
                <Button onClick={postTodo} variant="dark" id="button-addon2">
                    Add todo
                </Button>
                <div style={wrapperStyle}>
                    <Calendar fullscreen={false} onPanelChange={onPanelChange} />
                </div>
            </InputGroup>
            <div className='todo-cards'>
                {
                    status ? (
                        fetchedData.data.map((item) => {
                            const { Id, Text, Date } = item;
                            return (
                                <Card>
                                    <Card.Header>{Date}</Card.Header>
                                    <Card.Body>
                                        <Card.Title>Todo #{Id}</Card.Title>
                                        <Card.Text>
                                            {Text}
                                        </Card.Text>
                                        <Button onClick={() => deleteTodo(Id)} variant="primary">Delete todo</Button>
                                        <Button onClick={() => updateTodo(Id)} variant="primary">Update todo</Button>
                                    </Card.Body>
                                </Card>
                            );
                        })

                    ) : null
                }
            </div>
        </div>
    );
}
export default TodoList;