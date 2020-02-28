using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loan.Data.Models;

namespace Loan.Data
{
  
 public class BusinessLogic
 {
   public static List<string> UrlList { get; set; } = new List<string>();
    public static Subscribed ActivateSubscribed(decimal amount,string response,string userid,string username)
    {
      var _subscriber = new Subscribed();
      Subscribe subscribepackage;
      SubscribedMonth month;
      switch (amount)
      {
        case 5000:
           subscribepackage = Subscribe.Basic;
           month = SubscribedMonth.OneMonth ;
          break;
        case 10000:
          subscribepackage = Subscribe.Premium;
          month = SubscribedMonth.ThreeMonths;
          break;
        case 15000:
          subscribepackage = Subscribe.ultimate;
          month = SubscribedMonth.SixMonths;
          break;
        default:
          subscribepackage = Subscribe.Basic;
          month = SubscribedMonth.OneMonth;
          break;


      }

      DateTime date = DateTime.Now;
      var numbersofdays = (int) month * 30;
      TimeSpan aMonth = new System.TimeSpan(numbersofdays, 0, 0, 0);
      _subscriber.IsSubscribed = true;
      _subscriber.AmountSubscribed = amount;
      _subscriber.PaymentStatus = response;
      _subscriber.DateSubscribed = DateTime.Now;
      _subscriber.SubscribtionExpiryDate = date.Add(aMonth);
      _subscriber.Subscribe = subscribepackage;
      _subscriber.SubscribedMonth = month;
      _subscriber.UserId = userid;
      _subscriber.UserName = username;
      return _subscriber;

    }

   
  }
}
