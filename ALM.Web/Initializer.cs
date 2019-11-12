using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM.Web
{
    public static class Initializer
    {
        public static void Initialize(this BankRepository repository)
        {
            var customer1 = repository.AddCustomer("Albin", "Ljunghusen");
            var customer2 = repository.AddCustomer("Rickard", "Uttermalm");
            var customer3 = repository.AddCustomer("Fredrik", "Haglund");

            var account1 = repository.AddAccount(customer1);
            var account2 = repository.AddAccount(customer2);
            var account3 = repository.AddAccount(customer2);
            var account4 = repository.AddAccount(customer3);
            var account5 = repository.AddAccount(customer3);
            var account6 = repository.AddAccount(customer3);

            account1.Credit(1000);
            account2.Credit(4812);
            account3.Credit(1782512);
            account4.Credit(123);
            account5.Credit(0);
            account6.Credit(1337);
        }
    }
}
