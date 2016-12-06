using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConscienceLoan.ViewModel
{
    public class History
    {
        public int FinID { get; set; }
        public Nullable<Decimal> FinExpenditure { get; set; }
        public Nullable<Decimal> FinIncome { get; set; }
        public DateTime FinTimes { get; set; }
        public Nullable<Decimal> FinCurrentBalance { get; set; }
        public string FinRemarks { get; set; }
        public string FinFinType { get; set; }
        public Nullable<int> FinPoints { get; set; }
        public Nullable<int> UserID { get; set; }
        public string UserName { get; set; }
        public string UserTrueName { get; set; }
        public string UserIDCard { get; set; }
    }
}