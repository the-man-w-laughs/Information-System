export async function updateData(data) {
    try {
      const response = await fetch("http://localhost:5064/personal-info", {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
      });    
      if (!response.ok) {
        const errorMessage = await response.text();
        throw new Error(errorMessage);
      }
      return true;
    } catch (error) {
      console.error('Error:', error);
      return false;
    }
}

export async function deleteData(id) {
    try {
      const response = await fetch(`http://localhost:5064/personal-info/${id}`, {
        method: 'DELETE',
      });
  
      if (!response.ok) {
        const errorMessage = await response.text();
        throw new Error(errorMessage);
      }
      return true;
    } catch (error) {
      console.error('Error:', error);
      return false; // Возвращаем false, если произошла ошибка
    }
}

export async function fetchCitizenship() {
    try {
      const response = await fetch("http://localhost:5064/citizenship");
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      const result = await response.json();
      return result;
    } catch (error) {
      throw new Error(error.message);
    }
}

export async function fetchCity() {
    try {
      const response = await fetch("http://localhost:5064/city");
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      const result = await response.json();
      return result;
    } catch (error) {
      throw new Error(error.message);
    }
}

export async function fetchDisability() {
    try {
      const response = await fetch("http://localhost:5064/disability");
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      const result = await response.json();
      return result;
    } catch (error) {
      throw new Error(error.message);
    }
}

export async function fetchMaritalStatus() {
    try {
      const response = await fetch("http://localhost:5064/marital-status");
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      const result = await response.json();
      return result;
    } catch (error) {
      throw new Error(error.message);
    }
}

export async function addPersonalInfo(personalInfoData) {
    try {
      const response = await fetch("http://localhost:5064/personal-info", {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(personalInfoData),
      });    
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      return true;
    } catch (error) {
      console.error('Error:', error);
      return false;
    }
  }

export async function getPersonalInfoById(id) {
    try {
      const response = await fetch(`http://localhost:5064/personal-info/${id}`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
      });
      
      if (!response.ok) {
        const errorMessage = await response.text();
        throw new Error(errorMessage);
      }
      
      return await response.json();
    } catch (error) {
      console.error('Error:', error);
      return null;
    }
  }