using Services.Account;
using Services.Account.Models;
using Services.Common.Model;
using Services.Credit;
using Services.Deposit;
using Services.Transaction;
using Microsoft.Practices.Unity;

namespace Services.Common
{
    public class BankService : BaseService, IBankService
    {
        [Dependency]
        public IAccountService AccountService { get; set; }
        [Dependency]
        public ICreditService CreditService { get; set; }

        [Dependency]
        public IDepositService DepositService { get; set; }

        [Dependency]
        public ITransactionService TransactionService { get; set; }

        [Dependency]
        public ISystemInformationService SystemInformationService { get; set; }

        public BankService() : base()
        {
        }

        private void CloseBankDayWork()
        {
            DepositService.CloseBankDay();
            CreditService.CloseBankDay();
            SystemInformationService.IncreaseCurrentBankDay();
        }

        public AccountReportModel GenerateAccountReport()
        {
            AccountReportModel result = new AccountReportModel
            {
                DevelopmentFundAccount =
                    Mapper.Map<ORMLibrary.Account, AccountModel>(AccountService.GetDevelopmentFundAccount()),
                CashdeskAccount =
                    Mapper.Map<ORMLibrary.Account, AccountModel>(AccountService.GetCashDeskAccount()),
                Credits = CreditService.GetAll(),
                Deposits = DepositService.GetAll()
            };

            return result;
        }

        public TransactionReportModel GenerateTransactionReport(int day)
        {
            TransactionReportModel result = new TransactionReportModel
            {
                Transactions = TransactionService.GetAllByDay(day)
            };
            return result;
        }

        public void CloseBankDay()
        {
            CloseBankDayWork();
            Context.SaveChanges();
        }

        public void CloseBankMonth()
        {
            for (int i = 0; i < SystemInformationService.CountDaysInMonth; i++)
            {
                CloseBankDayWork();
            }

            Context.SaveChanges();
        }

        public void CloseBankYear()
        {
            for (int i = 0; i < SystemInformationService.CountDaysInYear; i++)
            {
                CloseBankDayWork();
            }

            Context.SaveChanges();
        }
    }
}
