using System;   //system is a namespace

namespace BankingApp       //namespace is just like a folder for your classes
{
    class Program
    {
        static void Main(string[] args)          //entry point
        {
            var account = new BankAccount("Ragul", 10000);
            Console.WriteLine($"Account {account.AcctNum} was created for {account.Owner} with {account.Balance} initial balance.");


            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);

            Console.WriteLine(account.GetAccountHistory());
        }
    }
}