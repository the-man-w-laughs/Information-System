using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication.Models.ViewModels
{
    public class Client
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        [RegularExpression(@"^[A-Za-z]+|[А-Яа-я]+$", ErrorMessage = "Фамилия может содержать только кириллицу или латиницу")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Имя")]
        [RegularExpression(@"^[A-Za-z]+|[А-Яа-я]+$", ErrorMessage = "Имя может содержать только кириллицу или латиницу")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Отчество")]
        [RegularExpression(@"^[A-Za-z]+|[А-Яа-я]+$", ErrorMessage = "Отчество может содержать только кириллицу или латиницу")]
        public string Patronymic { get; set; }

        [Required]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; } = new DateTime(2001, 1, 1);

        [Required]
        [Display(Name = "Пол")]
        public bool Gender { get; set; }

        [Required]
        [Display(Name = "Серия паспорта")]
        [RegularExpression("^[A-Z]{2}$", ErrorMessage = "Серия паспорта должна содержать две заглавные латинские буквы")]
        public string PassportSeries { get; set; }

        [Required]
        [Display(Name = "Номер паспорта")]
        [RegularExpression("^[0-9]{7}$", ErrorMessage = "Серия паспорта должна состоять из 7 цифр")]
        public string PassportNumber { get; set; }

        [Required]
        [Display(Name = "Кем выдан")]
        public string IssuedBy { get; set; }

        [Required]
        [Display(Name = "Дата выдачи")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime IssueDate { get; set; } = new DateTime(2003, 1, 1);

        [Required]
        [Display(Name = "Идентификационный номер")]
        [RegularExpression("^[0-9]{7}[A-Z]{1}[0-9]{3}[A-Z]{2}[0-9]{1}$", ErrorMessage = "Идентификационный номер должен быть записан в видел '0000000X000XX0'")]
        public string IdentificationNumber { get; set; }

        [Required]
        [Display(Name = "Место рождения")]
        public string BirthPlace { get; set; }

        [Required]
        [Display(Name = "Город фактического проживания")]
        public string ResidenceActualPlace { get; set; }

        [Required]
        [Display(Name = "Адрес фактического проживания")]
        public string ResidenceActualAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Домашний номер телефона")]
        [RegularExpression(@"^\+375-[0-9]{2}-[0-9]{7}$", ErrorMessage = "Номер телефона должен иметь формат: '+375-XX-XXXXXXX'")]
        public string HomePhoneNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Мобильный номер телефона")]
        [RegularExpression(@"^\+375-[0-9]{2}-[0-9]{7}$", ErrorMessage = "Номер телефона должен иметь формат: '+375-XX-XXXXXXX'")]
        public string MobilePhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Адрес прописки")]
        public string ResidenceAddress { get; set; }

        [Required]
        [Display(Name = "Семейное положение")]
        public string MaritalStatus { get; set; }

        [Required]
        [Display(Name = "Гражданство")]
        public string Citizenship { get; set; }

        [Required]
        [Display(Name = "Инвалидность")]
        public string Disability { get; set; }

        [Required]
        [Display(Name = "Пенсионер")]
        public bool Pensioner { get; set; }

        [Display(Name = "Ежемесячный доход")]
        [RegularExpression(@"^(0|\d{0,16}(\.\d{0,2})?)$", ErrorMessage = "Ежемесячный доход должен иметь формат: #.##")]
        public decimal MonthlyIncome { get; set; }

        public IEnumerable<string> Places { get; set; } = new List<string>();

        public IEnumerable<string> Citizenships { get; set; } = new List<string>();

        public IEnumerable<string> MartialStatuses { get; set; } = new List<string>();

        public IEnumerable<string> DisabilityStatuses { get; set; } = new List<string>();
    }
}
