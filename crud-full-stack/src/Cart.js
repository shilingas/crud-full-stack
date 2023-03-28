import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
const Cart = () => {
    const [data, setData] = useState([]);
    const [status, setStatus] = useState(false);
    const [total, setTotal] = useState(0);
    const [sum, setSum] = useState(0);
    const fetchData = async () => {
        const resp = await fetch('https://localhost:7206/api/Phone');
        const currData = await resp.json();
        setData(currData);
        setStatus(true);
    }
    const removeMe = (id) => {
        const newArray = data.filter((item) => item.id !== id);
        setData(newArray);
    }
    const addMe = (id) => {
        const newArray = data.map((item) => {
            if (item.id === id) {
                return { ...item, count: item.count + 1 };
            }
            return item;
        });
        setData(newArray);
    }
    const decreaseMe = (id) => {
        const newArray = data.map((item) => {
            if (item.id === id) {
                return { ...item, count: item.count - 1 };
            }
            return item;
        });
        setData(newArray);
    }
    const setAllTotals = () => {
        if (data.length > 0) {
            const arrayOfCounts = data.map((item) => {
                return item.count;
            })
            const tempCount = arrayOfCounts.reduce((a, b) => a + b);
            const arrayOfSums = data.map((item) => {
                return item.count * item.price;
            })
            const tempSum = arrayOfSums.reduce((a, b) => a + b);
            setTotal(tempCount);
            setSum(tempSum);
        }
    }
    React.useEffect(() => {
        if (status)
            setAllTotals();
    }, [data]);

    return (
        <div>
            <Link to="/">
                back to home page
            </Link>
            <p>hello, we will fetch data from our back end</p>
            {
                data.length === 0 ? <button onClick={() => fetchData()}>Get data...</button> : null
            }
            {
                status && data.map((item) => {
                    const { id, companyName, model, releaseYear, price, count } = item;
                    return (
                        <div className='cart-item'>
                            <p>{id}</p>
                            <p>{companyName}</p>
                            <p>{model}</p>
                            <p>{releaseYear}</p>
                            <p>{price}</p>
                            <p>{count}</p>
                            <button onClick={() => removeMe(id)}>Remove me</button>
                            <button onClick={() => addMe(id)}>Add</button>
                            <button onClick={() => decreaseMe(id)}>Decrease</button>
                        </div>
                    );
                })
            }
            {
                data.length > 0 ?
                    <div>
                        <p>Total amount of items: {total}</p>
                        <p>Total sum of items: {sum}</p>
                    </div> : null
            }
            {
                data.length > 0 ?
                    <button onClick={() => setData([])}>remove all</button> : null
            }
        </div>
    );
}
export default Cart;    