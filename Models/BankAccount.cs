namespace OopPractice;

public class BankAccount
{
    public string Owner { get; private set; }
    public decimal Balance { get; private set; }

    public BankAccount(string owner, decimal initialBalance){
        if (string.IsNullOrWhiteSpace(owner))
        {
            throw new ArgumentException("Owner can not be empty");
        }

        if (initialBalance < 0)
        {
            throw new ArgumentException("Initial balance can not be negative");
        }

        Owner = owner;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be positive");
        }

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be positive");
        }

        if (Balance < amount)
        {
           throw new InvalidOperationException("Not enough money for withdraw"); 
        }

        Balance -= amount;
    }

    public string PrintInfo()
    {
        return $"Owner: {Owner}, Balance: {Balance}";
    }
}