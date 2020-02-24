using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Data.Services
{
   public interface ISubscribed
   {
     void Add(Subscribed subscribed);
     void UpdateSubscribed(Subscribed subscribed);
     void DeleteSubscribtion(Subscribed subscribed);
     Subscribed GetSubscribed(int id);
     IEnumerable<Subscribed> GetAllSubscribed();
     void DeactivatedSub(string userid);
     void ActivatedSub(string userid);
     bool comit();

   }
}
