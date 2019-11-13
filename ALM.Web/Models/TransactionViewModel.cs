using System;
//DETTA E ETT FULHAX!   
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ALM.Web.Models
{
    public class TransactionViewModel
    {
        [Required]
        [Display(Name = "Account ID")]
        public int AccountId { get; set; } = 0;

        [Required]
        [Display(Name = "Amount")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; } = 0;

        public Account Account { get; set; }
    }
}
