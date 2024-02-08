import React from 'react';
import './error.css';

function ErrorModal({ message, onClose }) {
    return (
        <div className="error-modal">
            <p>{message}</p>
            <button onClick={onClose}>Close</button>
        </div>
    );
}

export default ErrorModal;