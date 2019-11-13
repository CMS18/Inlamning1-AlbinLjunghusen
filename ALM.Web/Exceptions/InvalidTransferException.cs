using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM.Web.Exceptions
{
    public class InvalidTransferException : Exception
    {
        public InvalidTransferException(string message) : base(message)
        {

        }
    }
}
