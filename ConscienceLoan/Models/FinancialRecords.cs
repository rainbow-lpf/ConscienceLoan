//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConscienceLoan.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FinancialRecords
    {
        public int FinID { get; set; }
        public Nullable<decimal> FinExpenditure { get; set; }
        public Nullable<decimal> FinIncome { get; set; }
        public Nullable<System.DateTime> FinTimes { get; set; }
        public Nullable<decimal> FinCurrentBalance { get; set; }
        public string FinRemarks { get; set; }
        public string FinFinType { get; set; }
        public Nullable<int> FinPoints { get; set; }
        public Nullable<int> FinUserID { get; set; }
    
        public virtual UserInfo UserInfo { get; set; }
    }
}