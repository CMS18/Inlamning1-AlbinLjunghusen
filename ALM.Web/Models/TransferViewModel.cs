using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ALM.Web.Models
{
    public class TransferViewModel
    {
        [Required]
        [Display(Name = "From Account")]
        public int FromAccountId { get; set; }
        [Required]
        [Display(Name = "To Account")]
        public int ToAccountId { get; set; }

        [Required]
        [Display(Name = "Amount")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; } 
    }
}
