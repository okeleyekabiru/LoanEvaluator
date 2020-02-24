using Loan.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Data.Services
{
  public  class LoanDbContext : DbContext 
    {
        public DbSet<MapLoans> MapLoandata { get; set; }
    }
}
