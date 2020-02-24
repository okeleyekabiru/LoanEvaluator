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
        public DbSet<Subscribed> Subscribed { get; set; }
        public DbSet<LoanProviders> LoanProviders { get; set; }
        public DbSet<ClickTracker> ClickTrackers { get; set; }
    }
}
