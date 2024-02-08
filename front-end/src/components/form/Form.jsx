import React, {useState, useEffect} from 'react';
import './form.css';
import InputMask from 'react-input-mask';
import { fetchCitizenship, fetchCity, fetchDisability, fetchMaritalStatus, addPersonalInfo, updateData } from '../../api/api';
import ErrorModal from '../error/Error';

export const Form =({ handleClose, initialData }) =>{

    const [formData, setFormData] = useState({
        lastName: '',
        firstName: '',
        patronymic: '',
        date: new Date(),
        gender: 'male',
        passportSeries: '',
        passportNumber: '',
        passportIssuedBy: '',
        passportIssueDate: new Date(),
        identificationNumber: '',
        placeOfBirth: '',
        currentCityId: '',
        currentAddress: '',
        homePhone: '',
        mobilePhone: '',
        email: '',
        workplace: '',
        position: '',
        registrationCityId: '',
        maritalStatusId: '',
        citizenshipId: '',
        disabilityId: '',
        isPensioner: '',
        monthlyIncome: ''
      });


    const [error, setError] = useState(null);


    useEffect(() => {
        if (initialData) {
            setFormData(initialData);
        }
    }, [initialData]);

    // const cities = [
    //     { id: '1', name: 'Минск' },
    //     { id: '2', name: 'Гомель' },
    //     { id: '3', name: 'Могилёв' },
    //     { id: '4', name: 'Брест' },
    //     { id: '5', name: 'Гродно' },
    //     { id: '6', name: 'Витебск' },
    // ];

    // const maritalStatusOptions = [
    //     { id: '1', name: 'Холост/Не замужем' },
    //     { id: '2', name: 'В браке' },
    //     { id: '3', name: 'Разведен/Разведена' },
    //     { id: '4', name: 'Вдовец/Вдова' },
    // ];

        // const citizenshipOptions = [
    //     { id: '1', name: 'Россия' },
    //     { id: '2', name: 'Украина' },
    //     { id: '3', name: 'Беларусь' },
    //     { id: '4', name: 'США' },
    //     { id: '5', name: 'Германия' },
    // ];

        // const disabilityOptions = [
    //     { id: '1', name: 'Отсутствует' },
    //     { id: '2', name: '1-я группа' },
    //     { id: '3', name: '2-я группа' },
    //     { id: '4', name: '3-я группа' },
    //     { id: '5', name: '4-я группа' },
    // ];

    const [cityOptions, setCityOptions] = useState([]);
    const [disabilityOptions, setDisabilityOptions] = useState([]);
    const [maritalStatusOptions, setMaritalStatusOptions] = useState([]);
    const [citizenshipOptions, setCitizenshipOptions] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
          try {
            const citizenship = await fetchCitizenship();
            setCitizenshipOptions(citizenship);

            const maritalStatusData = await fetchMaritalStatus();
            setMaritalStatusOptions(maritalStatusData);
    
            const disabilityData = await fetchDisability();
            setDisabilityOptions(disabilityData);

            const cityData = await fetchCity();
            setCityOptions(cityData);
          } catch (error) {
            setError(error.message);
          }
        };
    
        fetchData();
      }, []);


    const handleChange = (event) => {
        const { name, value } = event.target;
        let processedValue = value;

        console.log(name);
        if (name === 'passportSeries') {
            processedValue = value.toUpperCase().replace(/[^A-Z]/g, '').substring(0, 2);
          } else if (name === 'passportNumber') {
            processedValue = value.replace(/\D/g, '').substring(0, 7);
          }

        setFormData((prevData) => ({
            ...prevData,
            [name]: processedValue
        }));
    };

    const handleCheckboxChange = (event) => {
        const { name, checked } = event.target;
        setFormData((prevData) => ({
          ...prevData,
          [name]: checked
        }));
      };

    const handleGenderChange = (event) => {
        setFormData((prevData) => ({
            ...prevData,
            gender: event.target.value
        }));
    };

    const submitHandler = async(event) => {
        event.preventDefault();
    
        try {
            console.log('Form data:', formData);
            let success;
            if (initialData) {
                success = await updateData(formData);
            } else {
                success = await addPersonalInfo(formData);
            }
            if (success) {
                console.log('Personal info added successfully');
                handleFormClose()
            } else {
                console.error('Failed to add personal info');
                setError('Failed to add personal info');
            }
        } catch (error) {
            console.error('Error:', error);
        }
    };

    const handleFormClose = () => {
        handleClose()
    };

    return(
        <div id='wrapper'>
            <button class="close-button" onClick={handleFormClose}>&times;</button>
            <form onSubmit={submitHandler} className='sign-in'>
                <input
                    type="text"
                    name="lastName"
                    placeholder="Lastname"
                    value={formData.lastName}
                    onChange={handleChange}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input
                    type="text"
                    name="firstName"
                    placeholder="name"
                    value={formData.firstName}
                    onChange={handleChange}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input
                    type="text"
                    name="patronymic"
                    placeholder="Patronymic"
                    value={formData.patronymic}
                    onChange={handleChange}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input className="login-input"
                    type="date"
                    name="date"
                    value={formData.date}
                    max="2023-01-31"
                    onChange={handleChange}
                    required
                />
                <fieldset class="gender-selection">
                    <legend>Select a sex:</legend>
                    <div>
                        <input type="radio" id="men" name="sex" value="male" checked={formData.gender === 'male'} onChange={handleGenderChange}  />
                        <label for="huey">Men</label>
                    </div>
                    <div>
                        <input type="radio" id="women" name="sex" value="female"  checked={formData.gender === 'female'} onChange={handleGenderChange}  />
                        <label for="women">Women</label>
                    </div>
                </fieldset>
                <input
                    type="text"
                    name="passportSeries"
                    placeholder="passport series"
                    value={formData.passportSeries}
                    onChange={handleChange}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input
                    type="text"
                    name="passportNumber"
                    placeholder="passport number"
                    value={formData.passportNumber}
                    onChange={handleChange}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input
                    type="text"
                    name="passportIssuedBy"
                    placeholder="passport issued by"
                    value={formData.passportIssuedBy}
                    onChange={handleChange}
                    autoComplete="off"
                    className="login-input"
                    required
                />

                <input
                    type="date"
                    name="passportIssueDate"
                    placeholder="passport issue date"
                    value={formData.passportIssueDate}
                    max="2023-01-31"
                    onChange={handleChange}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input
                    type="text"
                    name="identificationNumber"
                    placeholder="identification number"
                    value={formData.identificationNumber}
                    onChange={handleChange}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input
                    type="text"
                    name="placeOfBirth"
                    placeholder="place of birth"
                    value={formData.placeOfBirth}
                    onChange={handleChange}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <select
                    name="currentCityId"
                    value={formData.currentCityId}
                    onChange={handleChange}
                    className="login-input"
                    placeholder = "current сity"
                    required
                >
                    {cityOptions.map(city => (
                        <option key={city.id} value={city.id}>{city.name}</option>
                    ))}
                </select>
                <input
                    type="text"
                    name="currentAddress"
                    placeholder="current address"
                    value={formData.currentAddress}
                    onChange={handleChange}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <InputMask
                    mask="+375 (99) 999-99-99"
                    type="text"
                    name="homePhone"
                    placeholder="home phone"
                    value={formData.homePhone}
                    onChange={handleChange}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <InputMask
                    mask="+375 (99) 999-99-99"
                    type="text"
                    name="mobilePhone"
                    placeholder="mobile phone"
                    value={formData.mobilePhone}
                    onChange={handleChange}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input
                    type="email"
                    name="email"
                    placeholder="email"
                    value={formData.email}
                    onChange={handleChange}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input
                    type="text"
                    name="workplace"
                    placeholder="workplace"
                    value={formData.workplace}
                    onChange={handleChange}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input
                    type="text"
                    name="position"
                    placeholder="position"
                    value={formData.position}
                    onChange={handleChange}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <select
                    name="registrationCityId"
                    value={formData.registrationCityId}
                    onChange={handleChange}
                    className="login-input"
                    required
                >
                    {cityOptions.map(city => (
                        <option key={city.id} value={city.id}>{city.name}</option>
                    ))}
                </select>
                <select
                    name="maritalStatusId"
                    value={formData.maritalStatusId}
                    onChange={handleChange}
                    className="login-input"
                    required
                >
                    {maritalStatusOptions.map(status => (
                        <option key={status.id} value={status.id}>{status.name}</option>
                    ))}
                </select>
                <select
                    name="citizenshipId"
                    value={formData.citizenshipId}
                    onChange={handleChange}
                    className="login-input"
                    required
                >
                    {citizenshipOptions.map(citizenship => (
                        <option key={citizenship.id} value={citizenship.id}>{citizenship.name}</option>
                    ))}
                </select>
                <select
                    name="disabilityId"
                    value={formData.disabilityId}
                    onChange={handleChange}
                    className="login-input"
                    required
                >
                    {disabilityOptions.map(disability => (
                        <option key={disability.id} value={disability.id}>{disability.name}</option>
                    ))}
                </select>
                <div className="checkbox-container">
                    <input
                        type="checkbox"
                        id="isPensioner"
                        name="isPensioner"
                        checked={formData.isPensioner}
                        onChange={handleCheckboxChange}
                        className="login-checkbox"
                        required
                    />
                    <label htmlFor="isPensioner" className="checkbox-label">Является ли пенсионером</label>
                </div>
                <input
                    type="text"
                    name="monthlyIncome"
                    placeholder="monthlyIncome"
                    value={formData.monthlyIncome}
                    onChange={handleChange}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <button type="submit" className="login-input">Добавить</button>
            </form>
            {error && <ErrorModal message={error} onClose={() => setError(null)} />}
        </div>
    )
}



