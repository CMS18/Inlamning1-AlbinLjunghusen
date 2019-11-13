using ALM.Web.Exceptions;
using ALM.Web.Models;
//DETTA E ETT FULHAX!   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM.Web
{
    public class Transactioner : ITransactioner
    {
        private readonly IBankRepository _repository;

        public Transactioner(IBankRepository repository)
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

        public string Transfer(int FromAccountId, int ToAccountId, decimal Amount)
        {
            if (FromAccountId == ToAccountId)
            {
                throw new InvalidTransferException("Account numbers must be different.");
            }
            else
            {
                var fromaccount = _repository.GetAccount(FromAccountId);
                if (fromaccount == null)
                {
                    throw new AccountNotFoundException(FromAccountId);
                }
                var toaccount = _repository.GetAccount(ToAccountId);
                if (toaccount == null)
                {
                    throw new AccountNotFoundException(ToAccountId);
                }

                Withdraw(FromAccountId, Amount);
                Deposit(ToAccountId, Amount);
            }

            var newbalancefrom = _repository.GetAccount(FromAccountId).Balance;
            var newbalanceto = _repository.GetAccount(ToAccountId).Balance;

            return Amount + " was transfered from account #" + FromAccountId + " to #" + ToAccountId +
                   ". Account #" + FromAccountId + " balance: " + newbalancefrom +
                   ". Account #" + ToAccountId + " balance: " + newbalanceto; 
        }
    }
}
