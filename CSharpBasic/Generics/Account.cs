namespace Generics
{
    public class Account
    {
        public string  Name { get; set; }
        public decimal Balance { get; set; }

        public Account(string name,decimal balance)
        {
            Name = name;
            Balance = balance;
        }
    }
}
