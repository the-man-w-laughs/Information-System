using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DBSetup
{
    public class PersonalInfoModelSetup : IEntityTypeConfiguration<PersonalInfoModel>
    {
        public void Configure(EntityTypeBuilder<PersonalInfoModel> entity)
        {
            var personalInfos = new List<PersonalInfoModel>()
            {
                new()
                {
                    Id = 1,
                    LastName = "Иванов",
                    FirstName = "Иван",
                    Patronymic = "Иванович",
                    DateOfBirth = new DateTime(1980, 5, 15),
                    PassportSeries = "AB",
                    PassportNumber = "123456",
                    PassportIssuedBy = "ОВД г. Минска",
                    PassportIssueDate = new DateTime(2005, 7, 20),
                    IdentificationNumber = "123456789012",
                    PlaceOfBirth = "Минск",
                    CurrentCityId = 1,
                    CurrentAddress = "ул. Примерная, д. 123, кв. 45",
                    HomePhone = "123-45-67",
                    MobilePhone = "987-65-43",
                    Email = "ivanov@example.com",
                    Workplace = "Примерная компания",
                    Position = "Главный специалист",
                    RegistrationCityId = 1,
                    MaritalStatusId = 2,
                    CitizenshipId = 1,
                    DisabilityId = 1,
                    IsPensioner = false,
                    MonthlyIncome = 3000.50m
                },
                new()
                {
                    Id = 2,
                    LastName = "Петров",
                    FirstName = "Петр",
                    Patronymic = "Петрович",
                    DateOfBirth = new DateTime(1995, 8, 25),
                    PassportSeries = "CD",
                    PassportNumber = "654321",
                    PassportIssuedBy = "ОВД г. Гродно",
                    PassportIssueDate = new DateTime(2010, 10, 5),
                    IdentificationNumber = "987654321012",
                    PlaceOfBirth = "Гродно",
                    CurrentCityId = 6,
                    CurrentAddress = "ул. Главная, д. 54, кв. 12",
                    HomePhone = "111-22-33",
                    MobilePhone = "999-88-77",
                    Email = "petrov@example.com",
                    Workplace = "Примерная организация",
                    Position = "Инженер",
                    RegistrationCityId = 6,
                    MaritalStatusId = 1,
                    CitizenshipId = 2,
                    DisabilityId = 3,
                    IsPensioner = false,
                    MonthlyIncome = 2500.75m
                },
                new()
                {
                    Id = 3,
                    LastName = "Сидорова",
                    FirstName = "Елена",
                    Patronymic = "Ивановна",
                    DateOfBirth = new DateTime(1988, 3, 10),
                    PassportSeries = "EF",
                    PassportNumber = "987654",
                    PassportIssuedBy = "ОВД г. Могилев",
                    PassportIssueDate = new DateTime(2008, 6, 15),
                    IdentificationNumber = "456789012345",
                    PlaceOfBirth = "Могилев",
                    CurrentCityId = 3,
                    CurrentAddress = "ул. Центральная, д. 78, кв. 23",
                    HomePhone = "333-44-55",
                    MobilePhone = "777-66-88",
                    Email = "sidorova@example.com",
                    Workplace = "Примерная компания",
                    Position = "Менеджер",
                    RegistrationCityId = 3,
                    MaritalStatusId = 2,
                    CitizenshipId = 1,
                    DisabilityId = 1,
                    IsPensioner = false,
                    MonthlyIncome = 3500.90m
                },
                new()
                {
                    Id = 4,
                    LastName = "Николаев",
                    FirstName = "Владимир",
                    Patronymic = "Петрович",
                    DateOfBirth = new DateTime(1950, 12, 5),
                    PassportSeries = "GH",
                    PassportNumber = "567890",
                    PassportIssuedBy = "ОВД г. Брест",
                    PassportIssueDate = new DateTime(1970, 2, 20),
                    IdentificationNumber = "567890123456",
                    PlaceOfBirth = "Брест",
                    CurrentCityId = 5,
                    CurrentAddress = "ул. Примерная, д. 10, кв. 5",
                    HomePhone = "123-45-67",
                    MobilePhone = "555-44-33",
                    Email = "nikolaev@example.com",
                    Workplace = "Пенсионер",
                    Position = "Пенсионер",
                    RegistrationCityId = 5,
                    MaritalStatusId = 4,
                    CitizenshipId = 2,
                    DisabilityId = 1,
                    IsPensioner = true,
                    MonthlyIncome = 1200.25m
                },
                new()
                {
                    Id = 5,
                    LastName = "Масюков",
                    FirstName = "Назар",
                    Patronymic = "Андреевич",
                    DateOfBirth = new DateTime(2003, 09, 27),
                    PassportSeries = "KL",
                    PassportNumber = "987654",
                    PassportIssuedBy = "ОВД г. Минск",
                    PassportIssueDate = new DateTime(2015, 8, 10),
                    IdentificationNumber = "876543210987",
                    PlaceOfBirth = "Минск",
                    CurrentCityId = 1,
                    CurrentAddress = "ул. Примерная, д. 20, кв. 15",
                    HomePhone = "111-22-33",
                    MobilePhone = "999-88-77",
                    Email = "masyukov@example.com",
                    Workplace = "Примерная компания",
                    Position = "Разработчик",
                    RegistrationCityId = 1,
                    MaritalStatusId = 1,
                    CitizenshipId = 1,
                    DisabilityId = 1,
                    IsPensioner = false,
                    MonthlyIncome = 4000.00m
                }
            };
            entity.HasData(personalInfos);
        }
    }
}
