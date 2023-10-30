using MongoDB.Driver;
using Rebar.Models;

namespace Rebar.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMongoCollection<Order> _orders;
        public AccountService(IRebarStoreDatabaseSettings settings,IMongoClient mongoClient)
        {
            var database=mongoClient.GetDatabase(settings.DatabaseName);
            _orders = database.GetCollection<Order>(settings.AccountCollectionName);
        }
        public Order CreateOrder(Order order)
        {
            _orders.InsertOne(order);
            return order;
        }

        public void DeleteOrder(Guid id)
        {
            _orders.DeleteOne(order => order.Id == id);
          
        }

        public List<Order> GetAllOrders()
        {
            return _orders.Find(orders => true).ToList();
        }

        public Order GetOrderById(Guid id)
        {
            return _orders.Find(order => order.Id == id).FirstOrDefault();

        }

        public void Update(Guid id, Order order)
        {
            _orders.ReplaceOne(order => order.Id == id, order);

        }
    }
}
