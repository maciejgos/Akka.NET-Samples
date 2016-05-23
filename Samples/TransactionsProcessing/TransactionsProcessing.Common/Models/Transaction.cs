using System;

namespace TransactionsProcessing.Common.Models
{
    public class Transaction : ITransaction
    {
        public string TransactionID { get; set; }
        public DateTime TransactionDate { get; set; } //YYYYmmdd
        public decimal Amount { get; set; } //-254.95
        public string Currency { get; set; } //PLN
        public string OrderID { get; set; }
    }
}
