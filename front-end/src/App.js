import React, { useState, useEffect } from "react";
import {Form} from "./components/form/Form";
import "./App.css";
import DataList from "./components/datalist/DataList";
import { deleteData, getPersonalInfoById } from './api/api';
import ErrorModal from "./components/error/Error";

function App() {
  const [personalInitialData, setPersonalInitialData] = useState(null);
  const [data, setData] = useState(null);
  const [error, setError] = useState(null);

  const [isFormOpen, setIsFormOpen] = useState(false);

  const mockDataList = [
    {id:1, firstName: 'Иван', lastName: 'Иванов', patronymic: 'Иванович' },
    {id:2, firstName: 'Петр', lastName: 'Петров', patronymic: 'Петрович' },
    {id:3, firstName: 'Сидор', lastName: 'Сидоров', patronymic: 'Сидорович' }
  ];

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("http://localhost:5064/citizenship");
        if (!response.ok) {
          throw new Error("Network response was not ok");
        }
        const result = await response.json();
        setData(result);
      } catch (error) {
        setError(error.message);
      }
    };

    fetchData();
  }, []);

  const handleEdit = async(id) => {
    const personalData = await getPersonalInfoById(id);
    if (personalData) {
      setPersonalInitialData(personalData);
      setIsFormOpen(true);
    } else {
      setError('Failed to fetch personal data.');
    }
  };

  const handleDelete = async (id) => {
    const success = await deleteData(id);
    if (!success) {
      setError('Failed to delete data.'); 
    }
  };

  const handleAdd = () => {
    setIsFormOpen(true);
  };

  const handleClose = () => {
    setIsFormOpen(false);
  };

  return (
    <div className="App">
      {!isFormOpen && 
        <div className="container">
          <button className="add-btn" onClick={() => handleAdd()}>Добавить</button>
        </div>
      }
        <div className="data-container">
          {isFormOpen && <Form handleClose={handleClose} initialData = {personalInitialData}/>}
          {!isFormOpen && <DataList dataList={mockDataList} handleEdit={handleEdit} handleDelete={handleDelete} />}
        </div>
        {error && <ErrorModal message={error} onClose={() => setError(null)} />}
    </div>
  );
}

export default App;
