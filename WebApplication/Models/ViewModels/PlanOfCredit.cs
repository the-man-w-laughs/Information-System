using ORMLibrary;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication.Models.ViewModels
{
    public class PlanOfCredit
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Период (в месяцах)")]
        public int MonthPeriod { get; set; }

        [Required]
        [Display(Name = "Процентов в год")]
        public double Percent { get; set; }

        [Display(Name = "Аннуитетный")]
        public bool Anuity { get; set; }

        [Display(Name = "Валюта")]
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public IEnumerable<Currency> Currencies { get; set; }

        [HiddenInput]
        public decimal? MinAmount { get; set; }
    }
}
