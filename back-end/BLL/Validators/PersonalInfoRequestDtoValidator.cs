using BLL.DTOs;
using FluentValidation;

namespace BLL.Validators
{
    public class PersonalInfoRequestDtoValidator : AbstractValidator<PersonalInfoRequestDto>
    {
        public PersonalInfoRequestDtoValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(dto => dto.LastName)
                .NotEmpty()
                .WithMessage("Фамилия обязательна")
                .Matches("^[a-zA-Zа-яА-Я]+$")
                .WithMessage("Фамилия должна содержать только буквы");

            RuleFor(dto => dto.FirstName)
                .NotEmpty()
                .WithMessage("Имя обязательно")
                .Matches("^[a-zA-Zа-яА-Я]+$")
                .WithMessage("Имя должно содержать только буквы");

            RuleFor(dto => dto.Patronymic)
                .Matches("^[a-zA-Zа-яА-Я]+$")
                .WithMessage("Отчество должно содержать только буквы");

            RuleFor(x => x.PassportNumber)
                .NotEmpty()
                .WithMessage("Номер паспорта обязателен.")
                // .Matches(@"^(AB|BM|HB|KH|MP|MO|KB|PP|SP|DP)\d{7}$")
                .Matches(@"^\d{7}$")
                // .WithMessage(
                //     "Неверный формат номера паспорта. Должен начинаться с двух букв и следовать за ними семь цифр."
                // )
                .WithMessage("Неверный формат номера паспорта. Должен состоять из 7 цифр.");

            RuleFor(x => x.IdentificationNumber)
                .NotEmpty()
                .WithMessage("Идентификационный номер обязателен.")
                .Matches(@"^[а-яА-Яa-zA-Z\d]{14}$")
                .WithMessage(
                    "Неверный формат идентификационного номера. Должен состоять из четырнадцати символов (цифр или букв)."
                );

            RuleFor(x => x.HomePhone)
                .Matches(@"^8\d{9}$")
                .WithMessage(
                    "Неверный формат номера домашнего телефона. Должен начинаться с '8' и следовать за ними девять цифр."
                )
                .When(x => x.HomePhone != null);

            RuleFor(x => x.MobilePhone)
                .Matches(@"^\+375(?:24|25|29|33|44)\d{7}$")
                .WithMessage(
                    "Неверный формат номера мобильного телефона. Должен начинаться с '+375' и следовать за ними девять цифр. Верные префиксы: 24, 25, 29(1-9), 33, 44."
                )
                .When(x => x.MobilePhone != null);

            RuleFor(x => x.PassportSeries)
                .NotEmpty()
                .WithMessage("Серия паспорта не может быть пустой строкой.");
            RuleFor(x => x.PassportIssuedBy)
                .NotEmpty()
                .WithMessage("Поле 'кем выдан паспорт' не может быть пустым.");
            RuleFor(x => x.PlaceOfBirth)
                .NotEmpty()
                .WithMessage("Место рождения не может быть пустым.");
            RuleFor(x => x.CurrentAddress)
                .NotEmpty()
                .WithMessage("Адрес фактического проживания не может быть пустым.");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("E-mail не может быть пустым.")
                .When(x => x.Email != null);
            RuleFor(x => x.Workplace)
                .NotEmpty()
                .WithMessage("Место работы не может быть пустым.")
                .When(x => x.Workplace != null);
            RuleFor(x => x.Position)
                .NotEmpty()
                .WithMessage("Должность не может быть пустой.")
                .When(x => x.Position != null);
        }
    }
}
