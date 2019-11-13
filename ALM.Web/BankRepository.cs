using ALM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM.Web
{
    public class BankRepository
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Account> Accounts { get; set; } = new List<Account>();

        public BankRepository()
        {
            this.Initialize();
        }

        public Customer AddCustomer(string firstName, string lastName)
        {
            var customer = new Customer
            {

                CustomerId = Customers.Any() ? Customers.Max(a => a.CustomerId) + 1 : 0,
                FirstName = firstName,
                LastName = lastName
            };
            Customers.Add(customer);
            return customer;
        }

        public Account AddAccount(Customer owner)
        {
            var account = new Account
            {
                AccountId = Accounts.Any() ? Accounts.Max(a => a.AccountId) + 1 : 0,
                Owner = owner
            };
            owner.Accounts.Add(account);
            Accounts.Add(account);
            return account;
        }

        public Account GetAccount(int accountId)
        {
            var account = Accounts.FirstOrDefault(a => a.AccountId == accountId);
            if (account == null)
            {
                throw new AccountNotFoundException(accountId);
            }
            return account;
        }

    }
}
