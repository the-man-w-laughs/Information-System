using ORMLibrary;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication.Models.ViewModels
{
    public class PlanOfDeposit
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Период (в днях)")]
        public int DayPeriod { get; set; }

        [Required]
        [Display(Name = "Процентов в год")]
        public double Percent { get; set; }

        [Display(Name = "Отзывной")]
        public bool Revocable { get; set; }

        [Display(Name = "Валюта")]
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public IEnumerable<Currency> Currencies { get; set; }

        [HiddenInput]
        public decimal? MinAmount { get; set; }
    }
}
