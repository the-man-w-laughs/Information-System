using ORMLibrary;
using Services.Account.Models;

namespace Services.Credit.Models
{
    public class PlanOfCreditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MonthPeriod { get; set; }
        public double Percent { get; set; }
        public bool Anuity { get; set; }
        public decimal? MinAmount { get; set; }
        public int MainAccountPlanId { get; set; }
        public int PercentAccountPlanId { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual PlanOfAccountModel MainPlanOfAccount { get; set; }
        public virtual PlanOfAccountModel PercentPlanOfAccount { get; set; }
    }
}
