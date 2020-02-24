using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loan.Data.Models;

namespace Loan.Data.Services
{
  public class Clicktrack:ITracker
  {
    private readonly LoanDbContext _db;

    public Clicktrack(LoanDbContext db)
    {
      _db = db;
    }

    public bool GetvaluebyproviderNameAndUserid(string providername, string Userid)
    {
      var item =_db.ClickTrackers.Where(r => r.UserId.Equals(Userid) && r.ProvideName.Equals(providername)).ToList();
      if (item.Count <= 0)
      {
        var click = new ClickTracker();
        click.ProvideName = providername;
        click.UserId = Userid;
        _db.ClickTrackers.Add(click);
        _db.SaveChanges();
        return false;
      }

   

      return true;
    }

    public void AddToTracker(string provider, string Userid)
    {
      if (!GetvaluebyproviderNameAndUserid(provider,Userid))
      {
        var click = new ClickTracker();
        click.ProvideName = provider;
        click.UserId = Userid;
        _db.ClickTrackers.Add(click);
        _db.SaveChanges();
      }

    }
  }
}
