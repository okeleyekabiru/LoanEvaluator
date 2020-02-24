using Loan.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Data.Services
{
    public class SqlliteDbContext : IMapLoan
    {
        public readonly LoanDbContext db;

        public SqlliteDbContext(LoanDbContext db)
        {
            this.db = db;
        }
        public void Add(MapLoans loan)
        {
             db.MapLoandata.Add(loan);
            db.SaveChanges();  
        }

        public MapLoans Get(int id)
        {
            return db.MapLoandata.FirstOrDefault(r => id == r.id);
        }

        public IEnumerable<MapLoans> GetAll(decimal min)
        {
        return    from map in db.MapLoandata
                where map.MaximumLoan >= min  && map.MinimumLoan <= min
                select map;
        }

        public IEnumerable<MapLoans> GetAlls()
        {
            return from r in db.MapLoandata
                orderby r.Rate
                select r;
        }

    }
}
