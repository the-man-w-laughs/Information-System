using ORMLibrary;
using Services.Account.Models;
using Services.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Account
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService() : base()
        {
            if (!Context.Accounts.Any())
            {
                InitAccounts();
            }
        }

        public AccountModel Create(AccountModel account, ClientModel client)
        {
            var plan = Context.PlanOfAccounts.FirstOrDefault(e => e.Id == account.PlanId);
            ORMLibrary.Account dbAccount = new ORMLibrary.Account()
            {
                AccountNumber = GenerateAccountNumber(plan.AccountNumber, client.Id),
                DebitValue = account.DebitValue,
                CreditValue = account.CreditValue,
                Balance = account.DebitValue - account.CreditValue,
                PlanOfAccount = plan,
            };

            dbAccount = Context.Accounts.Add(dbAccount);
            Context.SaveChanges();
            return Mapper.Map<ORMLibrary.Account, AccountModel>(dbAccount);
        }

        public IEnumerable<AccountModel> GetAll()
        {
            return Context.Accounts.ToArray().Select(Mapper.Map<ORMLibrary.Account, AccountModel>);
        }

        public ORMLibrary.Deposit CreateAccountsForDeposit(ORMLibrary.Deposit deposit)
        {
            number = Context.Accounts.Count(a => a.AccountNumber.StartsWith(deposit.PlanOfDeposit.MainPlanOfAccount.AccountNumber)) + 1;
            deposit.MainAccount = CreateAccount(deposit.PlanOfDeposit.MainPlanOfAccount, deposit.ClientId);
            deposit.PercentAccount = CreateAccount(deposit.PlanOfDeposit.PercentPlanOfAccount, deposit.ClientId);
            return deposit;
        }

        public ORMLibrary.Credit CreateAccountsForCredit(ORMLibrary.Credit credit)
        {
            number = Context.Accounts.Count(a => a.AccountNumber.StartsWith(credit.PlanOfCredit.MainPlanOfAccount.AccountNumber)) + 1;
            credit.MainAccount = CreateAccount(credit.PlanOfCredit.MainPlanOfAccount, credit.ClientId);
            credit.PercentAccount = CreateAccount(credit.PlanOfCredit.PercentPlanOfAccount, credit.ClientId);
            return credit;
        }

        private void InitAccounts()
        {
            Context.Accounts.AddRange(new List<ORMLibrary.Account>()
            {
                CreateBaseAccounts("1010", 0, 0),
                CreateBaseAccounts("7327", 0, 100000000000)
            });

            Context.SaveChanges();
        }

        private ORMLibrary.Account CreateBaseAccounts(string accountPlanNumber, decimal debit, decimal credit)
        {
            ORMLibrary.Account account = new ORMLibrary.Account()
            {
                Balance = credit - debit,
                CreditValue = credit,
                DebitValue = debit,
                PlanOfAccount = Context.PlanOfAccounts.FirstOrDefault(e => e.AccountNumber == accountPlanNumber),
                AccountNumber = GenerateAccountNumber(accountPlanNumber, 0)
            };
            return account;
        }

        private ORMLibrary.Account CreateAccount(PlanOfAccount plan, int cliendId)
        {
            return new ORMLibrary.Account()
            {
                DebitValue = 0,
                CreditValue = 0,
                Balance = 0,
                PlanOfAccount = plan,
                AccountNumber = GenerateAccountNumber(plan.AccountNumber, cliendId)
            };
        }

        private static int number = 1;

        private static string GenerateAccountNumber(string accountPlanNumber, int clientId)
        {
            if (clientId == 0)
                return accountPlanNumber + "000000000";

            var accountNumber = $"{accountPlanNumber}{clientId:00000}{number++:000}";
            var controlDigit = CalculateControlDigit(accountNumber);

            return $"{accountNumber}{controlDigit}";
        }

        static char CalculateControlDigit(string inputStr)
        {
            char[] reversedStr = inputStr.ToCharArray();
            Array.Reverse(reversedStr);

            int evenSum = 0;
            int oddSum = 0;

            for (int i = 0; i < reversedStr.Length; i++)
            {
                int digit = int.Parse(reversedStr[i].ToString());
                if (i % 2 == 0)
                {
                    evenSum += digit;
                }
                else
                {
                    oddSum += digit;
                }
            }

            int result = evenSum + 3 * oddSum;

            int controlDigit = (10 - result % 10) % 10;

            return controlDigit.ToString()[0];
        }

        public ORMLibrary.Account GetCashDeskAccount()
        {
            return Context.Accounts.FirstOrDefault(e => e.PlanOfAccount.AccountNumber == "1010");
        }

        public ORMLibrary.Account GetDevelopmentFundAccount()
        {
            return Context.Accounts.FirstOrDefault(e => e.PlanOfAccount.AccountNumber == "7327");
        }
    }
}
