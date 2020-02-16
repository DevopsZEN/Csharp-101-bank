using System;
using System.Collections.Generic;
using System.Text;

namespace BankStuff
{
    class Transaction
    {
        public decimal transactionAmount { get; }
        public DateTime transactionDate { get; }
        public string transactionNote { get; }

        public Transaction(decimal amount, DateTime date, string note)
        {
            this.transactionAmount = amount;
            this.transactionDate = date;
            this.transactionNote = note;
        }
    }
}
