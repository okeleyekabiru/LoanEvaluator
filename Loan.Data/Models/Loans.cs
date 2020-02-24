using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Data.Models
{
   public class Loans
    {
        public int id { get; set; }
       [Required] 
       public string Firstname { get; set; }
     
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Occupation { get; set; }
        [Display(Name = "Purpose")]
        public LoanPurpose LoanPurpose { get; set; }
        [Required]
        [Display(Name = "Amount")]
        public decimal amountToBeBorrrowed { get; set; }
        [Required]
        public decimal Rate { get; set; }
        [Required]
        public Duration  Duration  { get; set; }
        public  string WebsiteName { get; set; }
        public List<decimal> Calculatedloan { get; set; } = new List<decimal>();
      

    }
}
