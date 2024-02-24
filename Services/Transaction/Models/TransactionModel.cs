using System;
using Services.Account.Models;

namespace Services.Transaction.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDay { get; set; }
        public virtual AccountModel DebetAccount { get; set; }
        public virtual AccountModel CreditAccount { get; set; }
    }
}
