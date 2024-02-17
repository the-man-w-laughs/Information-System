import React from 'react';
import './dataList.css';

function DataList({ dataList, handleEdit, handleDelete }) {
    return (
        <div className="table-container">
            <table className="data-list">
                <thead>
                    <tr>
                        <th>Имя</th>
                        <th>Фамилия</th>
                        <th>Отчество</th>
                        <th>Действия</th>
                    </tr>
                </thead>
                <tbody>
                    {dataList.map((item, index) => (
                        <tr key={index}>
                            <td>{item.firstName}</td>
                            <td>{item.lastName}</td>
                            <td>{item.patronymic}</td>
                            <td>
                                <button className="edit-btn" onClick={() => handleEdit(item.id)}>Редактировать</button>
                                <button className="delete-btn" onClick={() => handleDelete(item.id)}>Удалить</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default DataList;