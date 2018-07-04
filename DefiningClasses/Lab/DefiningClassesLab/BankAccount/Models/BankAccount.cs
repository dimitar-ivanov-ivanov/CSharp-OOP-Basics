namespace BankAccount.Models
{
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
    }
}