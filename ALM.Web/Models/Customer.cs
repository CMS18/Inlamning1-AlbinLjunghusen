using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//DETTA E ETT FULHAX!   
namespace ALM.Web.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}
