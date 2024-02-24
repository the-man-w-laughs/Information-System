using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.ViewModels
{
    public class Deposit
    {
        public int Id { get; set; }

        public int PlanId { get; set; }

        public int ClientId { get; set; }

        [Display(Name = "Номер договора")]
        public int DepositNumber { get; set; }

        [Display(Name = "Дата начала")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Дата завершения")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Сумма")]
        public decimal Amount { get; set; }

        [Display(Name = "Текущая процентная сумма")]
        public decimal CurrentPercentAmount { get; set; }

        [Display(Name = "Процентная сумма за день")]
        public decimal PercentAmountForDay { get; set; }
        public bool IsCanWithdrawPercentsToday { get; set; }
        public bool IsCanCloseToday { get; set; }

        [Display(Name = "Клиент")]
        public Client Client { get; set; }

        [Display(Name = "План депозита")]
        public PlanOfDeposit PlanOfDeposit { get; set; }
    }
}
