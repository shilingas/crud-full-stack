import React, { useState } from 'react';

const Input = () => {
    const [object, setObject] = React.useState({
        id: 0,
        name: '',
        surname: '',
        age: '',
    });
    const [data, setData] = React.useState([]);
    const [status, setStatus] = React.useState(false);
    const [currentId, setCurrentId] = React.useState(0);
    const [isEditing, setIsEditing] = React.useState(false);
    const handleSubmit = (e) => {
        e.preventDefault();
        if (isEditing) {
            const newArray = data.map((item) => {
                if (parseInt(item.id) === parseInt(currentId)) {
                    return { ...item, name: object.name, age: object.age, surname: object.surname };
                }
                return item;
            });
            setObject({ ...object, name: '', age: '', surname: '' });
            setData(newArray);
        } else {
            setData([...data, object]);
            setStatus(true);
            setObject({ ...object, name: '', age: '', surname: '', id: object.id + 1 });
        }
    }
    const removeMe = (index) => {
        // newArray differs from data because in newArray we 'remove' item which id equals to parameter index
        const newArray = data.filter((item) => parseInt(item.id) !== parseInt(index));
        setData(newArray);
    }
    const updateMe = (index) => {
        setCurrentId(parseInt(index));
        setIsEditing(true);
        const editingObject = data.find((item) => item.id === index);
        setObject({ ...object, id: editingObject.id, name: editingObject.name, surname: editingObject.surname, age: editingObject.age });
    }
    return (
        <div className='input-container'>
            <form className='input-form' onSubmit={handleSubmit}>
                <input type='text' value={object.name} onChange={(e) => setObject({ ...object, name: e.target.value })} />
                <input type='text' value={object.surname} onChange={(e) => setObject({ ...object, surname: e.target.value })} />
                <input type='text' value={object.age} onChange={(e) => setObject({ ...object, age: e.target.value })} />
                <button>{isEditing ? 'edit' : 'submit'}</button>
            </form>
            <div className='input-items'>
                {
                    data.map((item) => {
                        const { name, surname, age, id } = item;
                        return (
                            <div className='input-item' key={id}>
                                <p className='input-item-value'>{name}</p>
                                <p className='input-item-value'>{surname}</p>
                                <p className='input-item-value'>{age}</p>
                                <button onClick={() => removeMe(id)}>remove me</button>
                                <button onClick={() => updateMe(id)}>update me</button>
                            </div>
                        );
                    })
                }
                {
                    data.length > 0 && <button onClick={() => setData([])}>delete all</button>
                }
            </div>
        </div>
    );
}
export default Input;