using System.Collections.Generic;
using Services.Account.Models;
using Services.Credit.Models;
using Services.Deposit.Models;

namespace Services.Common.Model
{
    public class AccountReportModel
    {
        public AccountModel DevelopmentFundAccount { get; set; }
        public AccountModel CashdeskAccount { get; set; }
        public IEnumerable<DepositModel> Deposits { get; set; }
        public IEnumerable<CreditModel> Credits { get; set; }
    }
}
