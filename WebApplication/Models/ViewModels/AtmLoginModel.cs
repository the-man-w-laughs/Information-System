using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.ViewModels
{
    public class AtmLoginModel
    {
        [Required]
        [StringLength(16)]
        [Display(Name = "Номер карты")]
        public string CreditCardNumber { get; set; }

        [Required]
        [StringLength(4)]
        [Display(Name = "Пин-код")]
        public string PinCode { get; set; }
    }
}
