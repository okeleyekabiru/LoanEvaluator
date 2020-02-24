using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loan.Data.Models;

namespace Loan.Data.Services
{
    public class MapLoanMemory: IMapLoan
    {
        private List<MapLoans> MapLoan = new List<MapLoans>();
       
        public IEnumerable<MapLoans> GetAll(decimal min)
        {
            var result = from map in MapLoan
                where map.MaximumLoan >= min
                select map;
            return result;
        }

        public MapLoans Get(int id)
        {
          return  MapLoan.FirstOrDefault(r => id == r.id);
        }
        public void Add(MapLoans loan)
        {
            
            MapLoan.Add(loan);
            loan.id = MapLoan.Max(r => r.id) + 1;


        }

        public IEnumerable<MapLoans> GetAlls()
        { 
            return MapLoan.OrderBy(r => r.Rate);
        }
    }
}
