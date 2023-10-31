using Rebar.Models;

namespace Rebar.Services
{
    public interface IAccountService
    {
        List <Order> GetAllOrders ();
        Order GetOrderById(string id);
        Order CreateOrder (Order order);
        void Update (string id,Order order);
        void DeleteOrder (string Id);

    }
}
