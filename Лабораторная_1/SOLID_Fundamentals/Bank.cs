namespace SOLID_Fundamentals//LSP
{
    public abstract class Account
    {
        public decimal Balance { get; protected set; }

        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public abstract WithdrawalResult Withdraw(decimal amount);

        public virtual decimal CalculateInterest()
        {
            return Balance * 0.01m;
        }
    }


    public class WithdrawalResult
    {
        public bool IsSuccess { get; }
        public string Message { get; }

        public WithdrawalResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }


    public class SavingsAccount : Account
    {
        public decimal MinimumBalance { get; } = 100m;

        public override WithdrawalResult Withdraw(decimal amount)
        {
            if (Balance - amount < MinimumBalance)
            {
                return new WithdrawalResult(false, "Cannot go below minimum balance");
            }
            Balance -= amount;
            return new WithdrawalResult(true, "");
        }
    }

    public class CheckingAccount : Account
    {
        public decimal OverdraftLimit { get; } = 500m;

        public override WithdrawalResult Withdraw(decimal amount)
        {
            if (Balance - amount < -OverdraftLimit)
            {
                return new WithdrawalResult(false, "Overdraft limit exceeded");
            }
            Balance -= amount;
            return new WithdrawalResult(true, "");
        }
    }

    public class FixedDepositAccount : Account
    {
        public DateTime MaturityDate { get; }
        

        public FixedDepositAccount(DateTime maturityDate)
        {
            Balance = 1111m;//
            MaturityDate = maturityDate;
        }

        public override WithdrawalResult Withdraw(decimal amount)
        {
            if (DateTime.Now < MaturityDate)
            {
                return new WithdrawalResult(false, "Cannot withdraw before maturity date");
            }

            if (amount > Balance)
            {
                return new WithdrawalResult(false, "Insufficient funds");
            }

            Balance -= amount;
            return new WithdrawalResult(true, "");
        }

        public override decimal CalculateInterest()
        {
            return Balance * 0.05m;
        }
    }

    public class Bank
    {
        public WithdrawalResult ProcessWithdrawal(Account account, decimal amount)
        {

            return account.Withdraw(amount);
        }

        public WithdrawalResult Transfer(Account from, Account to, decimal amount)
        {
            var withdrawalResult = ProcessWithdrawal(from, amount);

            if (withdrawalResult.IsSuccess) { to.Deposit(amount); }

            return withdrawalResult;
        }
    }
}