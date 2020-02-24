using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Data.Models
{
 public   class SubscriptionModel
 {
   public  decimal Basic { get; set; } = 5000m;
      public  decimal Premium { get; set; } = 10000m;
      public   decimal Ultimate { get; set; } = 15000m;
  }
}
