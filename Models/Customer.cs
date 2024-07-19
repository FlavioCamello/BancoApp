namespace BancoApp.Models
{
    public class Customer
    {
        public int CustomerId { get; private set; }
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private readonly List<Account> _accounts;
        public IReadOnlyCollection<Account> Accounts => _accounts.AsReadOnly();

        public Customer(string name, string cpf, string email)
        {
            Name = name;
            CPF = cpf;
            Email = email;
            CreatedAt = DateTime.Now;
            _accounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }
    }
}
