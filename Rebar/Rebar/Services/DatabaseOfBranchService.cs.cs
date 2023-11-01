using MongoDB.Driver;
using Rebar.Models;

namespace Rebar.Services
{
    public class DatabaseOfBranchService : IDatabaseOfBranchService
    {
        private readonly IMongoCollection<Account> _account;
        public DatabaseOfBranchService(IRebarStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _account = database.GetCollection<Account>(settings.AccountCollectionName);
        }
        public Account Create(Account account)
        {                   
             Console.WriteLine("the number of order for today: " + account.ListOrders.Count);
             Console.WriteLine("Summary of money in the cash register: " + account.LumpSum);
            _account.InsertOne(account);
            Console.WriteLine($"account numner: {account.Id} ");

            return account;
        }

        public List<Account> GetAccounts()
        {
            return _account.Find(accounts => true).ToList();
        }
    }
}
