using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Data.Models
{
 public   class MapLoans
    {
        [Required]
        public  int id { get; set; }
        [Required]
        public string Loansite { get; set; }
        [Required]
        public decimal Rate  { get; set; }
        [Required]
        public  decimal MinimumLoan { get; set; }
        [Required]
        public  decimal MaximumLoan { get; set; }
        [Required]
        public  string websitelink { get; set; }
        public decimal PaidAmount { get; set; }
      
    }
}
