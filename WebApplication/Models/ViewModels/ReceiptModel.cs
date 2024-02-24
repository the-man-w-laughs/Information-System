using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.ViewModels
{
    public class ReceiptModel
    {
        public int CreditId { get; set; }

        [Display(Name = "Номер карты")]
        public string CardNumber { get; set; }

        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Display(Name = "Сумма")]
        public decimal Amount { get; set; }

        [Display(Name = "Операция")]
        public string Operation { get; set; }
    }
}