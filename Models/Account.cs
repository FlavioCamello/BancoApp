namespace BancoApp.Models
{
    public class Account
    {
        public int AccountId { get; private set; }
        public int CustomerId { get; private set; }
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private readonly List<Transaction> _transactions;
        public IReadOnlyCollection<Transaction> Transactions => _transactions.AsReadOnly();

        public Customer Customer { get; private set; }

        public Account(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
            CreatedAt = DateTime.Now;
            _transactions = new List<Transaction>();
        }

        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
            Balance += transaction.Amount;
        }
    }
}
