using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Common.Model;

namespace Services.Common
{
    public interface IBankService
    {
        AccountReportModel GenerateAccountReport();
        TransactionReportModel GenerateTransactionReport(int day);
        void CloseBankDay();
        void CloseBankMonth();
        void CloseBankYear();
    }
}
