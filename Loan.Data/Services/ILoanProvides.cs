using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loan.Data.Models;

namespace Loan.Data.Services
{
public  interface ILoanProvides
{
  void AddLoanProvides(LoanProviders loanProviders);
  void DeleteLoanProvides(LoanProviders loanProviders);
  void UpdateLoanProvides(LoanProviders loanProviders);
  LoanProviders GetLoanProviders(int id);
  IEnumerable<LoanProviders> GetAllLoanProvider();
  Dictionary<string, int> GetProviderUniqueCount();
  Dictionary<string, int> GetProviderCount();
  LoanProviders GEtLoanProvidersbyName(string name);
  bool Commit();

}
}
