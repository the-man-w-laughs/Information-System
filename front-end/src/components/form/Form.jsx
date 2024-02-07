import React, {useState} from 'react';
import './form.css';
import InputMask from 'react-input-mask';

export const Form =() =>{
    const [lastName, setLastName] = useState('');
    const [firstName, setFirstName] = useState('');
    const [patronymic, setPatronymic] = useState('');
    const [date, setDate] = useState(new Date());
    const [gender, setGender] = useState('male');
    const [passportSeries, setPassportSeries] = useState('');
    const [passportNumber, setPassportNumber] = useState('');
    const [passportIssuedBy, setPassportIssuedBy] = useState('');
    const [passportIssueDate, setPassportIssueDate] = useState(new Date());
    const [identificationNumber, setIdentificationNumber] = useState('');
    const [placeOfBirth, setPlaceOfBirth] = useState('');
    const [currentCityId, setCurrentCityId] = useState('');
    const [currentAddress, setCurrentAddress] = useState('');
    const [homePhone, setHomePhone] = useState('');
    const [mobilePhone, setMobilePhone] = useState('');
    const [email, setEmail] = useState('');
    const [workplace, setWorkplace] = useState('');
    const [position, setPosition] = useState('');
    const [registrationCityId, setRegistrationCityId] = useState('');
    const [maritalStatusId, setMaritalStatusId] = useState('');
    const [citizenshipId, setCitizenshipId] = useState('');
    const [disabilityId, setDisabilityId] = useState('');
    const [isPensioner, setIsPensioner] = useState('');
    const [monthlyIncome, setMonthlyIncome] = useState('');

    const cities = [
        { id: '1', name: 'Минск' },
        { id: '2', name: 'Гомель' },
        { id: '3', name: 'Могилёв' },
        { id: '4', name: 'Брест' },
        { id: '5', name: 'Гродно' },
        { id: '6', name: 'Витебск' },
    ];

    const maritalStatusOptions = [
        { id: '1', name: 'Холост/Не замужем' },
        { id: '2', name: 'В браке' },
        { id: '3', name: 'Разведен/Разведена' },
        { id: '4', name: 'Вдовец/Вдова' },
    ];

    const citizenshipOptions = [
        { id: '1', name: 'Россия' },
        { id: '2', name: 'Украина' },
        { id: '3', name: 'Беларусь' },
        { id: '4', name: 'США' },
        { id: '5', name: 'Германия' },
    ];

    const disabilityOptions = [
        { id: '1', name: 'Отсутствует' },
        { id: '2', name: '1-я группа' },
        { id: '3', name: '2-я группа' },
        { id: '4', name: '3-я группа' },
        { id: '5', name: '4-я группа' },
    ];


    const lastNameChangeHandler = (event) => {
        setLastName(event.target.value);
    };

    const firstNameChangeHandler = (event) => {
        setFirstName(event.target.value);
    };

    const patronymicChangeHandler = (event) => {
        setPatronymic(event.target.value);
    };
    
    const handleGenderChange = (event) => {
        setGender(event.target.value);
    };

    const handleDateChange = (e) => {
        setDate(e.target.value);
    };

    const passportSeriesChangeHandler = (event) => {
        setPassportSeries(event.target.value.toUpperCase().replace(/[^A-Z]/g, '').substring(0, 2));
    };
    
    const passportNumberChangeHandler = (event) => {
        const input = event.target.value.replace(/\D/g, ''); // Удаление всех нецифровых символов
        setPassportNumber(input.substring(0, 7)); // Ограничение ввода до 7 символов
    };
    
    const positionChangeHandler = (event) => {
        setPosition(event.target.value);
    };
        
    const passportIssuedByChangeHandler = (event) => {
        setPassportIssuedBy(event.target.value);
    };
    
    const passportIssueDateChangeHandler = (event) => {
        setPassportIssueDate(event.target.value);
    };
    const identificationNumberChangeHandler = (event) => {
        setIdentificationNumber(event.target.value);
    };
    const placeOfBirthChangeHandler = (event) => {
        setPlaceOfBirth(event.target.value);
    };

    const currentCityIdChangeHandler = (event) => {
        setCurrentCityId(event.target.value);
    };
    const currentAddressChangeHandler = (event) => {
        setCurrentAddress(event.target.value);
    };

    const homePhoneChangeHandler = (event) => {
        setHomePhone(event.target.value);
    };
    const mobilePhoneChangeHandler = (event) => {
        setMobilePhone(event.target.value);
    };
    const emailChangeHandler = (event) => {
        setEmail(event.target.value);
    };
    const workplaceChangeHandler = (event) => {
        setWorkplace(event.target.value);
    };

    const registrationCityIdChangeHandler = (event) => {
        setRegistrationCityId(event.target.value);
    };

    const maritalStatusIdChangeHandler = (event) => {
        setMaritalStatusId(event.target.value);
    };
    const citizenshipIdChangeHandler = (event) => {
        setCitizenshipId(event.target.value);
    };
    const disabilityIdChangeHandler = (event) => {
        setDisabilityId(event.target.value);
    };
    const isPensionerChangeHandler = (event) => {
        setIsPensioner(event.target.value);
    };
    const monthlyIncomeChangeHandler = (event) => {
        setMonthlyIncome(event.target.value);
    };

    const closeForm= (event) => {
    }


    const submitHandler = (event) => {

    };

    return(
        <div id='wrapper'>
            <button class="close-button" onclick={closeForm}>&times;</button>
            <form onSubmit={submitHandler} className='sign-in'>
                <input
                    type="text"
                    name="lastName"
                    placeholder="Lastname"
                    value={lastName}
                    onChange={lastNameChangeHandler}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input
                    type="text"
                    name="firstName"
                    placeholder="name"
                    value={firstName}
                    onChange={firstNameChangeHandler}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input
                    type="text"
                    name="patronymic"
                    placeholder="Patronymic"
                    value={patronymic}
                    onChange={patronymicChangeHandler}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input className="login-input"
                    type="date"
                    value={date}
                    max="2023-01-31"
                    onChange={handleDateChange}
                    required
                />
                <fieldset class="gender-selection">
                    <legend>Select a sex:</legend>
                    <div>
                        <input type="radio" id="men" name="sex" value="male" checked={gender === 'male'} onChange={handleGenderChange}  />
                        <label for="huey">Men</label>
                    </div>
                    <div>
                        <input type="radio" id="women" name="sex" value="female"  checked={gender === 'female'} onChange={handleGenderChange}  />
                        <label for="women">Women</label>
                    </div>
                </fieldset>
                <input
                    type="text"
                    name="passportSeries"
                    placeholder="passport series"
                    value={passportSeries}
                    onChange={passportSeriesChangeHandler}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input
                    type="text"
                    name="passportNumber"
                    placeholder="passport number"
                    value={passportNumber}
                    onChange={passportNumberChangeHandler}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input
                    type="text"
                    name="passportIssuedBy"
                    placeholder="passport issued by"
                    value={passportIssuedBy}
                    onChange={passportIssuedByChangeHandler}
                    autoComplete="off"
                    className="login-input"
                    required
                />

                <input
                    type="date"
                    name="passportIssueDate"
                    placeholder="passport issue date"
                    value={passportIssueDate}
                    max="2023-01-31"
                    onChange={passportIssueDateChangeHandler}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input
                    type="text"
                    name="identificationNumber"
                    placeholder="identification number"
                    value={identificationNumber}
                    onChange={identificationNumberChangeHandler}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input
                    type="text"
                    name="placeOfBirth"
                    placeholder="place of birth"
                    value={placeOfBirth}
                    onChange={placeOfBirthChangeHandler}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <select
                    name="currentCityId"
                    value={currentCityId}
                    onChange={currentCityIdChangeHandler}
                    className="login-input"
                    required
                >
                    {cities.map(city => (
                        <option key={city.id} value={city.id}>{city.name}</option>
                    ))}
                </select>
                <input
                    type="text"
                    name="currentAddress"
                    placeholder="current address"
                    value={currentAddress}
                    onChange={currentAddressChangeHandler}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <InputMask
                    mask="+375 (99) 999-99-99"
                    type="text"
                    name="homePhone"
                    placeholder="home phone"
                    value={homePhone}
                    onChange={homePhoneChangeHandler}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <InputMask
                    mask="+375 (99) 999-99-99"
                    type="text"
                    name="mobilePhone"
                    placeholder="mobile phone"
                    value={mobilePhone}
                    onChange={mobilePhoneChangeHandler}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input
                    type="email"
                    name="email"
                    placeholder="email"
                    value={email}
                    onChange={emailChangeHandler}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input
                    type="text"
                    name="workplace"
                    placeholder="workplace"
                    value={workplace}
                    onChange={workplaceChangeHandler}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <input
                    type="text"
                    name="position"
                    placeholder="position"
                    value={position}
                    onChange={positionChangeHandler}
                    autoComplete="off"
                    className="login-input"
                    required
                />
                <select
                    name="registrationCityId"
                    value={registrationCityId}
                    onChange={registrationCityIdChangeHandler}
                    className="login-input"
                    required
                >
                    {cities.map(city => (
                        <option key={city.id} value={city.id}>{city.name}</option>
                    ))}
                </select>
                <select
                    name="maritalStatusId"
                    value={maritalStatusId}
                    onChange={maritalStatusIdChangeHandler}
                    className="login-input"
                    required
                >
                    {maritalStatusOptions.map(status => (
                        <option key={status.id} value={status.id}>{status.name}</option>
                    ))}
                </select>
                <select
                    name="citizenshipId"
                    value={citizenshipId}
                    onChange={citizenshipIdChangeHandler}
                    className="login-input"
                    required
                >
                    {citizenshipOptions.map(citizenship => (
                        <option key={citizenship.id} value={citizenship.id}>{citizenship.name}</option>
                    ))}
                </select>
                <select
                    name="disabilityId"
                    value={disabilityId}
                    onChange={disabilityIdChangeHandler}
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
                        checked={isPensioner}
                        onChange={isPensionerChangeHandler}
                        className="login-checkbox"
                        required
                    />
                    <label htmlFor="isPensioner" className="checkbox-label">Является ли пенсионером</label>
                </div>
                <input
                    type="text"
                    name="monthlyIncome"
                    placeholder="monthlyIncome"
                    value={monthlyIncome}
                    onChange={monthlyIncomeChangeHandler}
                    autoComplete="off"
                    className="login-input"
                    required
                />
            </form>
        </div>
    )
}



