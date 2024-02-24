using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.ViewModels
{
    public class Credit
    {
        public int Id { get; set; }

        public int PlanId { get; set; }

        public int ClientId { get; set; }

        [Display(Name = "Номер договора")]
        public int CreditNumber { get; set; }

        [Display(Name = "Дата начала")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Дата завершения")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Сумма")]
        public decimal Amount { get; set; }

        [Display(Name = "Баланс")]
        public decimal Balance { get; set; }

        [Display(Name = "Проценты к погашению поверх основной суммы")]

        public decimal CurrentPercentAmount { get; set; }

        [Display(Name = "Номер кредитной карты")]
        public string CreditCardNumber { get; set; }

        [Display(Name = "Пин-код кредитной карты")]
        public string CreditCardPin { get; set; }
        public bool IsCanPayPercentToday { get; set; }
        public bool IsCanCloseToday { get; set; }

        [Display(Name = "Клиент")]
        public Client Client { get; set; }

        [Display(Name = "План кредита")]
        public PlanOfCredit PlanOfCredit { get; set; }
    }
}
