using System.Collections.Generic;
using ALM.Web.Models;

namespace ALM.Web
{
    public interface IBankRepository
    {
        List<Account> Accounts { get; set; }
        List<Customer> Customers { get; set; }

        Account AddAccount(Customer owner);
        Customer AddCustomer(string firstName, string lastName);
        Account GetAccount(int accountId);
    }
}