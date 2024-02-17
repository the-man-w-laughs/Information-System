import React, { useState, useEffect } from "react";
import { Form } from "./components/form/Form";
import "./App.css";
import DataList from "./components/datalist/DataList";
import { deleteData, getPersonalInfoById, getAllPersonalInfo } from "./api/api";
import ErrorModal from "./components/error/Error";

function App() {
  const [personalInitialData, setPersonalInitialData] = useState(null);
  const [data, setData] = useState(null);
  const [error, setError] = useState(null);
  const [isFormOpen, setIsFormOpen] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await getAllPersonalInfo();
        setData(response);
      } catch (error) {
        setError(error.message);
      }
    };
    fetchData();
  }, []);

  const handleEdit = async (id) => {
    const personalData = await getPersonalInfoById(id);
    if (personalData) {
      setPersonalInitialData(personalData);
      setIsFormOpen(true);
    } else {
      setError("Failed to fetch personal data.");
    }
  };

  const handleDelete = async (id) => {
    const success = await deleteData(id);
    if (!success) {
      setError("Failed to delete data.");
    }
    try {
      const response = await getAllPersonalInfo();
      setData(response);
    } catch (error) {
      setError(error.message);
    }
  };

  const handleAdd = () => {
    setPersonalInitialData(null);
    setIsFormOpen(true);
  };

  const handleClose = () => {
    setIsFormOpen(false);
    const fetchData = async () => {
      try {
        const response = await getAllPersonalInfo();
        setData(response);
      } catch (error) {
        setError(error.message);
      }
    };
    fetchData();
  };

  return (
    <div className="App">
      {!isFormOpen && (
        <div className="container">
          <button className="add-btn" onClick={() => handleAdd()}>
            Добавить
          </button>
        </div>
      )}
      <div className="data-container">
        {isFormOpen ? (
          <Form handleClose={handleClose} initialData={personalInitialData} />
        ) : (
          data && (
            <DataList
              dataList={data}
              handleEdit={handleEdit}
              handleDelete={handleDelete}
            />
          )
        )}
      </div>
      {error && <ErrorModal message={error} onClose={() => setError(null)} />}
    </div>
  );
}

export default App;
