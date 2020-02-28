using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loan.Data.Models;
using Loan.Data.Services;

namespace Loan.Data.Services
{
    public class MemoryStorage :ILoan
{
   List<Loans> FilledLoan = new List<Loans>();

   

    public void Add(Loans loan)
    {

          FilledLoan.Add(loan);
            loan.id = FilledLoan.Max(r => r.id) + 1;


        }

    public Dictionary<decimal, decimal> CalculateInterest(decimal rate)
    {
      
       var filter = new Dictionary<decimal,decimal>();
        int count = 0;
        var Rate = rate;
        var Amount =  FilledLoan[0].amountToBeBorrrowed;
        var duration =  (decimal)FilledLoan[0].Duration + 1; 
        var interest =( Amount * Rate / duration) ;
        var LoanWithInterest = Amount + interest;
        var loanPerMonth = LoanWithInterest / duration;
        while (count < duration)
        {
            
            filter.Add( decimal.Round( LoanWithInterest-=loanPerMonth), decimal.Round(loanPerMonth));
            count++;
        }

        return filter;

    }
        
    public void Clear()
    {
        FilledLoan.Clear();
        
    }

    public Loans Get(int id)
    {
        return FilledLoan.FirstOrDefault(r => id == r.id);
    }
        public Loans Get()
        {
            return FilledLoan.FirstOrDefault();
        }


        public IEnumerable<Loans> GetAll()
    {
        var value = FilledLoan.OrderBy(loan => loan.LoanPurpose);
        return value;
    }

        public Loans GetLoans()
        {
            return FilledLoan[0];
        }
    }
}
