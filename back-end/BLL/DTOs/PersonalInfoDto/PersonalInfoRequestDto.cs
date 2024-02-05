namespace BLL.DTOs
{
    public class PersonalInfoRequestDto
    {
        // Фамилия
        public string? LastName { get; set; }

        // Имя
        public string? FirstName { get; set; }

        // Отчество
        public string? Patronymic { get; set; }

        // Дата рождения
        public DateTime? DateOfBirth { get; set; }

        // Серия паспорта
        public string? PassportSeries { get; set; }

        // № паспорта
        public string? PassportNumber { get; set; }

        // Кем выдан
        public string? PassportIssuedBy { get; set; }

        // Дата выдачи
        public DateTime? PassportIssueDate { get; set; }

        // Идент. номер
        public string? IdentificationNumber { get; set; }

        // Место рождения
        public string? PlaceOfBirth { get; set; }

        // Город факт. проживания
        public int? CurrentCityId { get; set; }

        // Адрес факт.проживания
        public string? CurrentAddress { get; set; }

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

        // Семейное положение
        public int? MaritalStatusId { get; set; }

        // Гражданство
        public int? CitizenshipId { get; set; }

        // Инвалидность
        public int? DisabilityId { get; set; }

        // Пенсионер
        public bool? IsPensioner { get; set; }

        // Ежемесячный доход
        public decimal? MonthlyIncome { get; set; }
    }
}
