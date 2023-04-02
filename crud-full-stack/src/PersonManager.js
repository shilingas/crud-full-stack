import React, { useState } from 'react';
import axios from 'axios';
const PersonManager = () => {
    const person = {
        id: 0,
        name: '',
        lastName: '',
        imageName: '',
        imageFile: null
    }
    const [personObject, setPersonObject] = useState(person);
    const handleFormSubmit = e => {
        e.preventDefault();
        const formData = new FormData();
        formData.append('id', personObject.id);
        formData.append('name', personObject.firstName);
        formData.append('lastName', personObject.lastName);
        formData.append('imageName', personObject.imageFile.name);
        formData.append('imageFile', personObject.imageFile);
        axios.post('https://localhost:7206/api/Person', formData);
    }
    return (
        <div>
            <form onSubmit={handleFormSubmit}>
                <input type="file" accept="image/*"
                    onChange={(e) => setPersonObject({ ...personObject, imageFile: e.target.files[0] })} />
                <input placeholder="name" name="name"
                    value={personObject.name}
                    onChange={(e) => setPersonObject({...personObject, name: e.target.value}) } />
                <input placeholder="surname" name="surname"
                    value={personObject.lastName}
                    onChange={(e) => setPersonObject({ ...personObject, lastName: e.target.value })} />
                <button>submit</button>
            </form>
        </div>
    );
}
export default PersonManager;