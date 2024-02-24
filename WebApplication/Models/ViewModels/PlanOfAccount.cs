using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.ViewModels
{
    public class PlanOfAccount
    {
        public int Id { get; set; }

        [Display(Name = "Номер счёта")]
        public string AccountNumber { get; set; }

        [Display(Name = "Название счёта")]
        public string AccountName { get; set; }

        [Display(Name = "Тип счёта")]
        public string AccountType { get; set; }
    }
}
