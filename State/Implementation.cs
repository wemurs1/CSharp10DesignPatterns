namespace State;

///<summary>
/// State
/// </summary>
public abstract class BankAccountState
{
    public BankAccount BankAccount { get; protected set; } = null!;
    public decimal Balance { get; protected set; }

    public abstract void Deposit(decimal amount);
    public abstract void Withdraw(decimal amount);
}

/// <summary>
/// ConcreteState
/// </summary>
public class RegularState : BankAccountState
{
    public RegularState(decimal balance, BankAccount bankAccount)
    {
        Balance = balance;
        BankAccount = bankAccount;
    }

    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, depositing {amount}");
        Balance += amount;
    }

    public override void Withdraw(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, withdrawing {amount} from {Balance}");
        // change state to overdrawn when withdrawing results in less than zero
        Balance -= amount;
        if (Balance < 0)
        {
            // change state to overdrawn
            BankAccount.BankAccountState = new OverdrawnState(Balance, BankAccount);
        }
    }
}
/// <summary>
/// ConcreteState
/// </summary>
public class OverdrawnState : BankAccountState
{
    public OverdrawnState(decimal balance, BankAccount bankAccount)
    {
        Balance = balance;
        BankAccount = bankAccount;
    }

    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, depositing {amount}");
        Balance += amount;
        if (Balance >= 0)
        {
            // change state to regular
            BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
        }
    }

    public override void Withdraw(decimal amount)
    {
        // cannot withdraw
        Console.WriteLine($"In {GetType()}, cannot withdraw, balance {Balance}");
    }
}

/// <summary>
/// Context
/// </summary>
public class BankAccount
{
    public BankAccountState BankAccountState { get; set; }
    public decimal Balance { get { return BankAccountState.Balance; } }

    public BankAccount()
    {
        BankAccountState = new RegularState(200, this);
    }

    /// <summary>
    /// Request a deposit
    /// </summary>
    public void Deposit(decimal amount)
    {
        BankAccountState.Deposit(amount);
    }

    public void Withdraw(decimal amount)
    {
        BankAccountState.Withdraw(amount);
    }
}