import React, { useState, useEffect } from "react";
import logo from "./logo.svg";
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
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>

        {data && (
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
        )}
      </header>
    </div>
  );
}

export default App;
