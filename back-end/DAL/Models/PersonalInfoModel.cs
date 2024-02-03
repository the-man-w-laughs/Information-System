namespace DAL.Models
{
    public class PersonalInfo
    {
        public int Id { get; set; }
        // Фамилия
        public string LastName { get; set; } = string.Empty;
        // Имя
        public string FirstName { get; set; } = string.Empty;
        // Отчество
        public string Patronymic { get; set; } = string.Empty;
        // Дата рождения 
        public DateTime DateOfBirth { get; set; }
        // Серия паспорта
        public string PassportSeries { get; set; } = string.Empty;
        // № паспорта
        public string PassportNumber { get; set; } = string.Empty;
        // Кем выдан
        public string PassportIssuedBy { get; set; } = string.Empty;
        // Дата выдачи
        public DateTime PassportIssueDate { get; set; }
        // Идент. номер
        public string IdentificationNumber { get; set; } = string.Empty;
        // Место рождения
        public string PlaceOfBirth { get; set; } = string.Empty;
        // Город факт. проживания
        public CityModel? CurrentCity { get; set; } = null;
        // Адрес факт.проживания
        public string CurrentAddress { get; set; } = string.Empty;
        // Телефон дом
        public string HomePhone { get; set; } = string.Empty;
        // Телефон моб
        public string MobilePhone { get; set; } = string.Empty;
        // E-mail
        public string Email { get; set; } = string.Empty;
        // Место работы
        public string Workplace { get; set; } = string.Empty;
        // Должность
        public string Position { get; set; } = string.Empty;
        // Город прописки
        public CityModel? RegistrationCity { get; set; } = null;
        // Семейное положение
        public MaritalStatusModel? MaritalStatus { get; set; } = null;
        // Гражданство
        public CitizenshipModel? Citizenship { get; set; } = null;
        // Инвалидность
        public DisabilityModel? Disability { get; set; } = null;
        // Пенсионер
        public bool IsPensioner { get; set; }
        // Ежемесячный доход
        public decimal MonthlyIncome { get; set; }
    }
}