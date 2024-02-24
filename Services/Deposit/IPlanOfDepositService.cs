using System.Collections.Generic;
using Services.Deposit.Models;

namespace Services.Deposit
{
    public interface IPlanOfDepositService
    {
        void Create(PlanOfDepositModel plan);
        IEnumerable<PlanOfDepositModel> GetAll();
    }
}
