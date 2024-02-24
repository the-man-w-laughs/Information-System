using System.Collections.Generic;
using Services.Account.Models;
using Services.Client.Models;

namespace Services.Account
{
    public interface IAccountService
    {
        AccountModel Create(AccountModel account, ClientModel client);
        IEnumerable<AccountModel> GetAll();

        ORMLibrary.Deposit CreateAccountsForDeposit(ORMLibrary.Deposit deposit);
        ORMLibrary.Credit CreateAccountsForCredit(ORMLibrary.Credit credit);
        ORMLibrary.Account GetCashDeskAccount();
        ORMLibrary.Account GetDevelopmentFundAccount();
    }
}
