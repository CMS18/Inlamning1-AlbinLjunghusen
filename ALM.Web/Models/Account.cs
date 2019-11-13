using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//DETTA E ETT FULHAX!   
namespace ALM.Web.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public Customer Owner { get; set; }
        public Decimal Balance { get; private set; }

        public void Credit(decimal amount)
        {
            Balance += amount;
        }

        public void Debit(decimal amount)
        {
            Balance -= amount;
        }
    }
}
