namespace Bank_Account_Methods
{
    using System;
    using Bank_Account_Methods.Models;

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
            acc.Deposit(15);
            acc.Withdraw(10);

            Console.WriteLine(acc);
        }
    }
}