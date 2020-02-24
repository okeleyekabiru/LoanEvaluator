using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayStack.Net;

namespace ShopyEcomerce
{
  public class PayStack
  {
    
    public static string PayStackApi(string email,int amount)
    {
//      var results =
      var testOrLiveSecret = ConfigurationManager.AppSettings["PayStackSecret"];
      var api = new PayStackApi(testOrLiveSecret);
      var response = api.Transactions.Initialize(email, amount);
      if (response.Status)
      { 
        return response.Data.AuthorizationUrl;

      }
    
        return response.Message;
      
      

  }
}
}
