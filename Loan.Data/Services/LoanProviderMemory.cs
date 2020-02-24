using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loan.Data.Models;

namespace Loan.Data.Services
{
  public class LoanProviderMemory : ILoanProvides
  {
    private readonly LoanDbContext _db;

    public LoanProviderMemory(LoanDbContext db)
    {
      _db = db;
    }

    public void AddLoanProvides(LoanProviders loanProviders)
    {
      _db.LoanProviders.Add(loanProviders);
    }

    public void DeleteLoanProvides(LoanProviders loanProviders)
    {
      _db.LoanProviders.Remove(loanProviders);
    }

    public void UpdateLoanProvides(LoanProviders loanProviders)
    {
      _db.Entry(loanProviders).State = EntityState.Modified;
    }

    public LoanProviders GetLoanProviders(int id)
    {
      return _db.LoanProviders.Find(id);
    }

    public IEnumerable<LoanProviders> GetAllLoanProvider()
    {
      return _db.LoanProviders.ToList();
    }

    public Dictionary<string, int> GetProviderUniqueCount()
    {
      var dicloan = new Dictionary<string, int>();
      var item = _db.LoanProviders.ToList();
      foreach (var val in item)
      {
        dicloan.Add(val.ProviderName, val.UniqueCountVisit);
      }

      return dicloan;
    }

    public Dictionary<string, int> GetProviderCount()
    {
      var dicloan = new Dictionary<string, int>();
      var item = _db.LoanProviders.ToList();
      foreach (var val in item)
      {
        dicloan.Add(val.ProviderName, val.CountVisit);
      }

      return dicloan;
    }

    public LoanProviders GEtLoanProvidersbyName(string name)
    {
     return _db.LoanProviders.FirstOrDefault(r => r.ProviderName == name);
    }

    public bool Commit()
    {
    return  _db.SaveChanges() > 0;
    }
  }
}