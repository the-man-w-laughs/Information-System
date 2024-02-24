using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Account.Models;
using Services.Client.Models;

namespace Services.Deposit.Models
{
    public class DepositModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PlanId { get; set; }
        public string DepositNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MainAccountId { get; set; }
        public int PercentAccountId { get; set; }
        public decimal Amount { get; set; }
        public virtual AccountModel MainAccount { get; set; }
        public virtual AccountModel PercentAccount { get; set; }
        public virtual ClientModel Client { get; set; }
        public virtual PlanOfDepositModel PlanOfDeposit { get; set; }
    }
}
