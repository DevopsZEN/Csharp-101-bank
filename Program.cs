using System;
using BankStuff;
namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello to our Bank");
            // Let's test some of our code here:
            // First we create an account on our bank:
            var bankAccount = new BankAccount("Kendra", 10000);
            bankAccount.MakeDeposite(200, DateTime.Now, "This is so cool");
            bankAccount.MakeDeposite(500, DateTime.Now, "Ole");
            bankAccount.MakeWithDraw(100, DateTime.Now, "This is so cool");
            Console.WriteLine(bankAccount.bankAccountTransactionsReport());
        }
    }
}
