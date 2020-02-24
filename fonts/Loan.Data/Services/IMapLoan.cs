using Loan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Data.Services
{

    public interface IMapLoan
    {
        IEnumerable<MapLoans> GetAll(decimal min);
        MapLoans Get(int id);
        void Add(MapLoans loan);
        IEnumerable<MapLoans> GetAlls();
    }
}