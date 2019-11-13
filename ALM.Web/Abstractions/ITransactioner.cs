using ALM.Web.Models;

namespace ALM.Web
{
    public interface ITransactioner
    {
        decimal Deposit(Account account, decimal amount);
        decimal Deposit(int accountId, decimal amount);
        decimal Withdraw(Account account, decimal amount);
        decimal Withdraw(int accountId, decimal amount);

        string Transfer(int fromaccount, int toaccount, decimal amount);
    }
}