namespace Test_Client.Models
{
    using System;

    public class BankAccount
    {
        private int id;
        private decimal balance;

        public BankAccount()
        {

        }

        public BankAccount(int id, decimal balance)
        {
            this.Id = id;
            this.Balance = balance;
        }

        public int Id { get => id; set => id = value; }

        public decimal Balance { get => balance; set => balance = value; }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return $"Account ID{id}, balance {balance:f2}";
        }
    }
}