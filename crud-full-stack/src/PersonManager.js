import React, { useState } from 'react';
import axios from 'axios';
const PersonManager = () => {
    const [selectedFile, setSelectedFile] = useState('');
    const onFileChange = (e) => {
        setSelectedFile(e.target.files[0]);
    }
    const fileData = () => {
        if (selectedFile) {
            return (
                <div>
                    <h2>File Details:</h2>
                    <p>File Name: {selectedFile.name}</p>
                    <p>File Type: {selectedFile.type}</p>
                    <p>
                        Modified: {selectedFile.lastModifiedDate.toDateString()}
                    </p>
                </div>
            );
        } else {
            return (
                <div>
                    <br />
                    <h4>Choose before Pressing the Upload button</h4>
                </div>
            );
        }
    }
    const [fetchedData, setFetchedData] = React.useState([]);
    const [name, setName] = React.useState('');
    const [surname, setSurname] = React.useState('');
    const [status, setStatus] = React.useState(false);
    const [isUpdating, setIsUpdating] = React.useState(false);
    const [currentId, setCurrentId] = React.useState('');
    const [statusForAction, setStatusForAction] = React.useState({
        status: false,
        message: '',
    });
    
 //   React.useEffect(() => {
   //     axios.get('https://localhost:7206/api/Person').then(resp => {
   //         setFetchedData(resp);
   //         setStatus(true);
   //     })
  //  }, [fetchedData]);
    const submitForm = (e) => {
        const formData = new FormData();
        formData.append("Name", selectedFile.name);
        formData.append("File", selectedFile);
        e.preventDefault();
        if (name && surname) {
            axios.post('https://localhost:7206/api/Person', {
                name: name,
                surname: surname,
                FileName: selectedFile.name,
                File: selectedFile,
            }, {
                headers: {
                    "Content-Type": "multipart/form-data"
                },
            }).then(resp => {
                console.log(resp);
            });
            setName('');
            setSurname('');
        } if (isUpdating) {

            axios.put(`https://localhost:7206/api/Person/${currentId}`, {
                name: name,
                surname: surname,
            }).then(
                axios.get('https://localhost:7206/api/Person').then(resp => {
                    setFetchedData(resp);
                    setStatus(true);
                })
            );
        }
        else {
            setStatusForAction({ status: true, message: 'should not be empty, enter values again' });
        }
    }
    React.useEffect(() => {
        const timeout = setTimeout(() => {
            setStatusForAction({ status: false, message: '' });
        }, 2000);
        return () => clearTimeout(timeout);
    }, [statusForAction]);
    const removeMe = (id) => {
        axios.delete(`https://localhost:7206/api/Person/${id}`).then(
            axios.get('https://localhost:7206/api/Person').then(resp => {
                setFetchedData(resp);
                setStatus(true);
            })
        )
    }
    const updateMe = (id) => {
        setCurrentId(parseInt(id));
        const findPerson = fetchedData.data.find(item => item.id === id);
        setName(findPerson.name);
        setSurname(findPerson.surname);
        setIsUpdating(true);
    }
    return (
        <div>
            {
                statusForAction.status ? <p>{statusForAction.message}</p> : null
            }
            <p>Manager</p>
            <form onSubmit={submitForm}>
                <input type='text' placeholder={'enter a name'} value={name} onChange={(e) => setName(e.target.value)} />
                <input type='text' placeholder={'enter a surname'} value={surname} onChange={(e) => setSurname(e.target.value)} />
                <div>
                    <p>file upload...</p>
                    <input type='file' onChange={(e) => onFileChange(e)} />
                    {fileData()}
                </div>
                <button>{isUpdating ? 'update' : 'add to db'}</button>
            </form>
            {
                status ?
                    fetchedData.data.map((item) => {
                        const { id, name, surname } = item;
                        return (
                            <div>
                                <p>{id}</p>
                                <p>{name}</p>
                                <p>{surname}</p>
                                <button onClick={() => removeMe(id)}>remove me</button>
                                <button onClick={() => updateMe(id)}>update me</button>
                            </div>
                        );
                    })
                    : null
            }
        </div>
    );
}
export default PersonManager;