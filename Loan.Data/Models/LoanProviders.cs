using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Data.Models
{
 public class LoanProviders
  {
    public  int Id { get; set; }
    public string ProviderName { get; set; }
    public int UniqueCountVisit { get; set; } = 0;
    public int CountVisit { get; set; } = 0;
    public decimal AverageAmountRequest { get; set; } = 0m;
    public Duration Duration { get; set; }
  }
}
