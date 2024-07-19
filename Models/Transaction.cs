namespace BancoApp.Models
{
    public class Transaction
    {
        public int TransactionId { get; private set; }
        public int AccountId { get; private set; }
        public string TransactionType { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime TransactionDate { get; private set; }

        public Account Account { get; private set; }

        public Transaction(string transactionType, decimal amount)
        {
            TransactionType = transactionType;
            Amount = amount;
            TransactionDate = DateTime.Now;
        }
    }
}
