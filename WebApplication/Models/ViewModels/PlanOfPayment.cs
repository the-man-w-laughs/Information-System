using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.ViewModels
{
    public class PlanOfPayment
    {
        public int CreditId { get; set; }

        [Display(Name = "Текущий день")]
        public DateTime CurrentDay { get; set; }

        [Display(Name = "График платежей")]
        public IDictionary<DateTime, decimal> PaymentSchedule { get; set; }
    }
}
