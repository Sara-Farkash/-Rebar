using Rebar.Models;

namespace Rebar.Services
{
    public interface IDatabaseOfBranchService
    {
        //updating the amount of money for that day + adding an account to the cash register
        //returns the number of orders for that day
        List<Account> GetAccounts();
        Account Create(Account account);
       

        

    }
}
