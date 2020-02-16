using System;
using System.Collections.Generic;
using System.Text;

namespace BankStuff
{
    public class BankAccount
    {
        public string accountNumber { get; }
        public string accountOwner { get; }
        public DateTime accountCreationDate { get; }
        public decimal accountBalance 
        { 
            get
            {
                decimal balance = 0;
                foreach(var item in allTransaction)
                {
                    balance += item.transactionAmount;
                }
                return balance;
            }
        }
        public static int seedAccountNumber = 1234567890;

        List<Transaction> allTransaction = new List<Transaction>();
        public BankAccount(string accountOwnerName, decimal accountInitialBalance)
        {
            this.accountOwner = accountOwnerName;
            MakeDeposite(accountInitialBalance, DateTime.Now, "Initial deposite");
            this.accountNumber = seedAccountNumber.ToString();
            seedAccountNumber++;
        }

        public void MakeDeposite(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The amount must be positive");
            }
            // Let's do the deposite transaction:
            allTransaction.Add(new Transaction(amount, date, note));
        }

        public void MakeWithDraw(decimal amount, DateTime date, string note)
        {
            if(amount <= 0) 
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The amount is out for the range must be positive and not null");
            }
            if(this.accountBalance - amount < 0)
            {
                throw new InvalidOperationException("You don't have money to make this transaction!");
            }
            // Let's do the WithDraw transaction:
            allTransaction.Add(new Transaction(-amount, date, note));
        }

        public string bankAccountTransactionsReport()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"{this.accountOwner} you have {this.accountBalance} in you account");
            report.AppendLine("****************************************************");
            report.AppendLine("Date\t\tAmount\t\tNote");
            foreach(var item in allTransaction)
            {
                report.AppendLine($"{item.transactionDate.ToShortDateString().ToString()}\t{item.transactionAmount}\t{item.transactionNote}");
            }
            return report.ToString();
        }
    }
}
