using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.ViewModels
{
    public class CreateDepositModel
    {
        public int Id { get; set; }

        [Display(Name = "План")]
        public int PlanId { get; set; }

        [Display(Name = "Клиент")]
        public int ClientId { get; set; }

        [Required]
        [RegularExpression(@"\d{9}", ErrorMessage = "Номер договора должен состоять из 9 цифр.")]
        [Display(Name = "Номер договора")]
        public string DepositNumber { get; set; }

        [Required]
        [Display(Name = "Сумма")]
        public decimal Amount { get; set; }

        public IEnumerable<PlanOfDeposit> DepositPlans { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }
}
