using MongoDB.Driver;
using Rebar.Models;
using System.Text.RegularExpressions;

namespace Rebar.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMongoCollection<Order> _orders;
        private readonly IMongoCollection<Menu> _menu;
        public AccountService(IRebarStoreDatabaseSettings settings,IMongoClient mongoClient)
        {
            var database=mongoClient.GetDatabase(settings.DatabaseName);
            _orders = database.GetCollection<Order>(settings.AccountCollectionName);
            _menu= database.GetCollection<Menu>(settings.AccountCollectionName);
        }
  
        public Order CreateOrder(Order order)
        {                 
                foreach (var shakes in order.ListShakes)
                {                  
                   order.TotalPrice += (double)shakes.PriceForSize;
                }
                if (order.IsHaveCoupon)
                {
                    if (Enum.IsDefined(typeof(DiscountsAndPromotions), order.DiscountsAndPromotionsForPerson))
                    {                       
                        order.TotalPrice = CouponCodeCalculation(order);
                    }
                }
                
                _orders.InsertOne(order);
                Console.WriteLine($"order numner: {order.Id} is save and the total price: {order.TotalPrice}");
                return order;        
        }

        public void DeleteOrder(string id)
        {
            _orders.DeleteOne(order => order.Id == id);
          
        }

        public List<Order> GetAllOrders()
        {
            return _orders.Find(orders => true).ToList();
        }

        public Order GetOrderById(string id)
        {
            return _orders.Find(order => order.Id == id).FirstOrDefault();

        }

        public void Update(string id, Order updatedOrder)
        {
            Order existingOrder = GetOrderById(id);

            existingOrder.NameCustomer = updatedOrder.NameCustomer;
            existingOrder.DateOrder = updatedOrder.DateOrder;
            existingOrder.DiscountsAndPromotionsForPerson = updatedOrder.DiscountsAndPromotionsForPerson;
            existingOrder.IsHaveCoupon = updatedOrder.IsHaveCoupon;
            existingOrder.ListShakes = updatedOrder.ListShakes;
            double newTotalPrice = 0;
            foreach (var shake in updatedOrder.ListShakes)
            {
                newTotalPrice = newTotalPrice + (double)shake.PriceForSize;
            }

            existingOrder.TotalPrice = newTotalPrice;
            if (updatedOrder.IsHaveCoupon)
            { 
                existingOrder.TotalPrice = CouponCodeCalculation(existingOrder);
            }                                    
            // Save the updated order back to the database
            _orders.ReplaceOne(o => o.Id == id, existingOrder);
        }

        public double CouponCodeCalculation(Order order)
        {          
            DiscountsAndPromotions discountType = order.DiscountsAndPromotionsForPerson;
            double discountPercentage = (int)discountType;
            discountPercentage /= 100.0;
            double discountAmount = order.TotalPrice * discountPercentage;
            order.TotalPrice -= discountAmount;

            return order.TotalPrice;
        }
        //public bool IsShakeExsistInMenu(Shake shake)
        //{

          
        //    Shake shake1 = _menu.ShakesList.Find(shake => shake.Id == shake1.Id).FirstOrDefault();
        //    if (shake1 != null)
        //    {
        //        return true;

        //    }
        //    return false;
        //}
    }
}
