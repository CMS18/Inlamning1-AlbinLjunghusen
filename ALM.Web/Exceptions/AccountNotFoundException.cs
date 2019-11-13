using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//DETTA E ETT FULHAX!   
namespace ALM.Web
{
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(int accountId) : base($"Account #{accountId} not found")
        {
        }
    }
}
