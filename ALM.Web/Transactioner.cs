using ALM.Web.Models;
//DETTA E ETT FULHAX!   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM.Web
{
    public class Transactioner
    {
        private readonly BankRepository _repository;

        public Transactioner(BankRepository repository)
        {
            _repository = repository;
        }

        public Transactioner()
        {

        }

        public decimal Deposit(Account account, decimal amount)
        {
            account.Credit(amount);
            return account.Balance;
        }

        public decimal Deposit(int accountId, decimal amount)
        {
            var account = _repository.GetAccount(accountId);
            if (account == null)
            {
                throw new AccountNotFoundException(accountId);
            }
            return Deposit(account, amount);
        }


        public decimal Withdraw(Account account, decimal amount)
        {
            if (account.Balance < amount)
            {
                throw new InvalidTransactionException($"Cant Withdraw {amount} from account #{account.AccountId}. Balance is only {account.Balance}.");
            }
            account.Debit(amount);
            return account.Balance;
        }

        public decimal Withdraw(int accountId, decimal amount)
        {
            var account = _repository.GetAccount(accountId);
            if (account == null)
            {
                throw new AccountNotFoundException(accountId);
            }
            return Withdraw(account, amount);
        }


    }
}
