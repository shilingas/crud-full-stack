import React, { useState } from 'react';
import axios from 'axios';
const FileUpload = () => {
    const [selectedFile, setSelectedFile] = useState('');
    const onFileChange = (e) => {
        setSelectedFile(e.target.files[0]);
    }
    const onFileUpload = (e) => {
        const formData = new FormData();
        formData.append("Name", selectedFile.name);
        formData.append("File", selectedFile);
        console.log(formData);
        axios.post("https://localhost:7206/api/FileUpload", formData, {
            headers: {
                "Content-Type": "multipart/form-data"
            },
        });
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
    return (
        <div>
            <p>file upload...</p>
            <input type='file' onChange={(e) => onFileChange(e)} />
            <button onClick={(e) => onFileUpload(e)}>upload</button>
            {fileData()}
        </div>
    );
}

export default FileUpload;