import React, { useState, useEffect } from "react";
import {Form} from "./components/form/Form";
import "./App.css";

function App() {
  const [data, setData] = useState(null);
  const [error, setError] = useState(null);

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

  return (
    <div className="App">
      <header className="App-header">
        <Form/>
        {/* {data && (
          <div>
            <h2>Data from the server:</h2>
            <ul>
              {data.map((item) => (
                <li key={item.id}>
                  {item.id} - {item.name}
                </li>
              ))}
            </ul>
          </div>
        )}

        {error && (
          <div>
            <h2>Error:</h2>
            <p>{error}</p>
          </div>
        )} */}
      </header>
    </div>
  );
}

export default App;
