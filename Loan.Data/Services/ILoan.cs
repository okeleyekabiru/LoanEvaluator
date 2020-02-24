using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loan.Data.Models;

namespace Loan.Data.Services
{
 public   interface ILoan
    {
        IEnumerable<Loans> GetAll();

        void Add(Loans loan);
        Loans Get(int id);
        Loans Get();
        Loans GetLoans();

        List<decimal> CalculateInterest(decimal rate);
        void Clear();
    }
}
