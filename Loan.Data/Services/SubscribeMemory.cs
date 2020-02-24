using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Data.Services
{
 public class SubscribeMemory:ISubscribed
  {
    private readonly LoanDbContext _db;

    public  SubscribeMemory(LoanDbContext db)
    {
      _db = db;
    }
    public void Add(Subscribed subscribed)
    {
      _db.Subscribed.Add(subscribed);
    }

    public void UpdateSubscribed(Subscribed subscribed)
    {
      _db.Entry(subscribed).State = EntityState.Modified;
    }

    public void DeleteSubscribtion(Subscribed subscribed)
    {
      _db.Subscribed.Remove(subscribed);
    }

    public Subscribed GetSubscribed(int id)
    {
     return _db.Subscribed.Find(id);
    }

    public IEnumerable<Subscribed> GetAllSubscribed()
    {
      return _db.Subscribed.ToList();
    }

    public void DeactivatedSub(string userid)
    {
    var model = _db.Subscribed.Where(r => r.SubscribtionExpiryDate < DateTime.Now).ToList();
   var va= model.FirstOrDefault(r => r.IsSubscribed );
   va.IsSubscribed = false;
   _db.Entry(va).State = EntityState.Modified;
    _db.SaveChanges();

    }   public void ActivatedSub(string userid)
    {
    var model = _db.Subscribed.Where(r => r.SubscribtionExpiryDate < DateTime.Now).ToList();
   var va= model.FirstOrDefault(r => r.IsSubscribed );
   va.IsSubscribed = false;
   _db.Entry(va).State = EntityState.Modified;
    _db.SaveChanges();

    }

    public bool comit()
    {
    return  _db.SaveChanges() > 0;
    }
  }
}
