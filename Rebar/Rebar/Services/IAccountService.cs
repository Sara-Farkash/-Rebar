using Rebar.Models;

namespace Rebar.Services
{
    public interface IAccountService
    {
        List <Order> GetAllOrders ();
        Order GetOrderById(Guid id);
        Order CreateOrder (Order order);
        void Update (Guid id,Order order);
        void DeleteOrder (Guid Id);

    }
}
