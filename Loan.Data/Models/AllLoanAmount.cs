using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Data.Models
{
 public class AllLoanAmount
  {
    public int LoanProviderId { get; set; }
    public string providerName { get; set; }
    public decimal AverageAmount { get; set; }
  }
}
