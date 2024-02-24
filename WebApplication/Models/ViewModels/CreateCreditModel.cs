using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.ViewModels
{
    public class CreateCreditModel
    {
        public int Id { get; set; }

        [Display(Name = "План")]
        public int PlanId { get; set; }

        [Display(Name = "Клиент")]
        public int ClientId { get; set; }

        [Required]
        [RegularExpression(@"\d{9}", ErrorMessage = "Номер договора должен состоять из 9 цифр.")]
        [Display(Name = "Номер договора")]
        public string CreditNumber { get; set; }

        [Display(Name = "Сумма")]
        public decimal Amount { get; set; }

        [Display(Name = "Создать кредитную карту")]
        public bool CreateCreditCard { get; set; }

        public IEnumerable<PlanOfCredit> CreditPlans { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }
}
