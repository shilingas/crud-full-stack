import React, { useState } from 'react';
import axios from 'axios';
import './PersonManager.css';
const PersonManager = () => {
    const [data, setData] = useState([]);
    const [status, setStatus] = useState(false);
    const person = {
        id: 0,
        firstName: '',
        lastName: '',
        imageName: '',

        imageFile: null
    }
    const [personObject, setPersonObject] = useState(person);
    const handleFormSubmit = e => {
        e.preventDefault();
        const formData = new FormData();
        formData.append('id', personObject.id);
        formData.append('firstName', personObject.firstName);
        formData.append('lastName', personObject.lastName);
        formData.append('imageName', personObject.imageFile.name);
        formData.append('imageFile', personObject.imageFile);
        axios.post('https://localhost:7206/api/Person', formData);
        setPersonObject({ ...personObject, firstName: '', lastName: '' });
    }
    const getData = async () => {
        await axios.get('https://localhost:7206/api/Person').then(resp => {
            setData(resp);
            setStatus(true);
        })
    }
    return (
        <div>
            <form onSubmit={handleFormSubmit}>
                <input type="file"
                    onChange={(e) => setPersonObject({ ...personObject, imageFile: e.target.files[0] })} />
                <input placeholder="name" name="name"
                    value={personObject.firstName}
                    onChange={(e) => setPersonObject({ ...personObject, firstName: e.target.value })} />
                <input placeholder="surname" name="surname"
                    value={personObject.lastName}
                    onChange={(e) => setPersonObject({ ...personObject, lastName: e.target.value })} />
                <button>submit</button>
            </form>
            <button onClick={() => getData()}>receive data from back end</button>
            {
                status ? (
                    data.data.map((item) => {
                        const { id, firstName, lastName, imageName } = item;
                        console.log('/crud-full-stack/crudd-backend/Images/' + imageName);
                        return (
                            <div>
                                <p>{firstName}</p>
                                <p>{lastName}</p>
                                <img className='person-img' src={URL.createObjectURL(personObject.imageFile)} alt="no photo" />
                            </div>
                        );
                    })
                ) : null
            }
        </div>
    );
}
export default PersonManager;