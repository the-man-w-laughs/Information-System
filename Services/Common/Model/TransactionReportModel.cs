using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Transaction.Models;

namespace Services.Common.Model
{
    public class TransactionReportModel
    {
        public IEnumerable<TransactionModel> Transactions { get; set; }
    }
}
