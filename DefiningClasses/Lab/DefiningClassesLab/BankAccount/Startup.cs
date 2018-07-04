namespace BankAccount
{
    using System;
    using BankAccount.Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        public static void Execute()
        {
            var acc = new BankAccount();
            acc.Id = 1;
            acc.Balance = 15;

            Console.WriteLine($"Account {acc.Id}, balance {acc.Balance}");
        }
    }
}