namespace BLL.DTOs
{
    public class PersonalInfoRequestDto
    {
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
        public int CurrentCityId { get; set; }

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
        public int RegistrationCityId { get; set; }

        // Семейное положение
        public int MaritalStatusId { get; set; }

        // Гражданство
        public int CitizenshipId { get; set; }

        // Инвалидность
        public int DisabilityId { get; set; }

        // Пенсионер
        public bool IsPensioner { get; set; }

        // Ежемесячный доход
        public decimal MonthlyIncome { get; set; }
    }
}
