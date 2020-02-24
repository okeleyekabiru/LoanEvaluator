using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Loan.Data { 
  public  class Subscribed
  {
    public int Id { get; set; }
    public bool IsSubscribed { get; set; } = false;
    public Subscribe Subscribe { get; set; }
    public string UserId { get; set; }
    public string PaymentStatus { get; set; }
    public decimal AmountSubscribed { get; set; }
    public SubscribedMonth SubscribedMonth  { get; set; }
    public string UserName { get; set; }
    public DateTime DateSubscribed { get; set; }
    public DateTime SubscribtionExpiryDate { get; set; }
  }
}
