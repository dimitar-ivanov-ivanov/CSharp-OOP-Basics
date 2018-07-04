namespace Test_Client.Models
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private Dictionary<int, BankAccount> accounts;
        private const string TerminatingCommand = "End";

        public Engine()
        {
            this.accounts = new Dictionary<int, BankAccount>();
        }

        public void Run()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != TerminatingCommand)
            {
                var command = args[0];

                var id = int.Parse(args[1]);

                if (!accounts.ContainsKey(id) && command != "Create")
                {
                    Console.WriteLine("Account does not exist");
                    args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                switch (command)
                {
                    case "Create":
                        if (this.accounts.ContainsKey(id))
                        {
                            Console.WriteLine("Account already exists");
                        }
                        else
                        {
                            this.accounts.Add(id, new BankAccount());
                            this.accounts[id].Id = id;
                        }
                        break;
                    case "Deposit":
                        var amount = decimal.Parse(args[2]);
                        this.accounts[id].Deposit(amount);
                        break;
                    case "Withdraw":
                        amount = decimal.Parse(args[2]);

                        if (amount > this.accounts[id].Balance)
                        {
                            Console.WriteLine("Insufficient balance");
                        }
                        else
                        {
                            this.accounts[id].Withdraw(amount);
                        }
                        break;
                    case "Print":
                        this.accounts[id].Print();
                        break;
                    default:
                        break;
                }

                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}