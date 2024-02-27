using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORMLibrary
{
    [Table("Currency")]
    public class Currency
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
