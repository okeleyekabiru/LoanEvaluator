using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Data.Services
{
  public interface ITracker
  {
    bool GetvaluebyproviderNameAndUserid(string providername, string Userid);
    void AddToTracker(string provider, string Userid);
  }
}
