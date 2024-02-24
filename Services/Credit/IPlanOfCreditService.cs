using System.Collections.Generic;
using Services.Credit.Models;

namespace Services.Credit
{
    public interface IPlanOfCreditService
    {
        void Create(PlanOfCreditModel plan);
        IEnumerable<PlanOfCreditModel> GetAll();
    }
}
