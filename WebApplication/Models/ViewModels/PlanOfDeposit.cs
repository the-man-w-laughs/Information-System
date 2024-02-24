using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApplication.Models.ViewModels
{
    public class PlanOfDeposit
    {
        [HiddenInput]
        public int Id { get; set; }

        public int CurrencyId { get; set; }

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

        [HiddenInput]
        public decimal? MinAmount { get; set; }
    }
}
