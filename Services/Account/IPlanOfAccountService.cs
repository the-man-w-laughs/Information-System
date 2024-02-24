using System.Collections.Generic;
using Services.Account.Models;
using ORMLibrary;

namespace Services.Account
{
    public interface IPlanOfAccountService
    {
        IEnumerable<PlanOfAccountModel> GetAll();

        PlanOfAccount GetByNumber(string number);

        PlanOfAccount GetById(int id);
    }
}
