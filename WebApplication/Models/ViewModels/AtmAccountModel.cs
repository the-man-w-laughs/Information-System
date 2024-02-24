using Services.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.ViewModels
{
    public class AtmAccountModel
    {
        public int CreditId { get; set; }

        [Display(Name = "Номер карты")]
        public string CardNumber { get; set; }

        [Display(Name = "Сумма")]
        public decimal Amount { get; set; }
    }
}
