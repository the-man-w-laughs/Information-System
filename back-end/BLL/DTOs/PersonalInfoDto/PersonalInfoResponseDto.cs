namespace BLL.DTOs
{
    public class PersonalInfoResponseDto
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
        public int? CurrentCityId { get; set; }
        public string? CurrentCity { get; set; } = null;

        // Адрес факт.проживания
        public string CurrentAddress { get; set; } = string.Empty;

        // Телефон дом
        public string? HomePhone { get; set; }

        // Телефон моб
        public string? MobilePhone { get; set; }

        // E-mail
        public string? Email { get; set; }

        // Место работы
        public string? Workplace { get; set; }

        // Должность
        public string? Position { get; set; }

        // Город прописки
        public int? RegistrationCityId { get; set; }
        public string? RegistrationCity { get; set; } = null;

        // Семейное положение
        public int? MaritalStatusId { get; set; }
        public string? MaritalStatus { get; set; } = null;

        // Гражданство
        public int? CitizenshipId { get; set; }
        public string? Citizenship { get; set; } = null;

        // Инвалидность
        public int? DisabilityId { get; set; }
        public string? Disability { get; set; } = null;

        // Пенсионер
        public bool IsPensioner { get; set; }

        // Ежемесячный доход
        public decimal? MonthlyIncome { get; set; }
    }
}
