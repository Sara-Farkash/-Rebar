using MongoDB.Driver;
using Rebar.Models;
using System.Text.RegularExpressions;

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
        //לפני שיצרנו הזמנה 
        //אנחנו בודקים 3 דברים:
        //1.האם כמות השייקים שלנו עומדת מעל 10 
        //2. האם שם הלקוח תקין
        //3.האם יש בכלל שייקים מוזמנים בהזמנה
        public Order CreateOrder(Order order)
        {
            //אין לנו קאצ איפה כדאי ואיך לזרוק שגיאה?
            if (order.ListShakes.Count > 10)
                throw new Exception($"the number order {order.Id} Exceeded the amount of shakes that can be ordered!");

            string pattern = "^[A-Za-z]+$";
            if(!Regex.IsMatch(order.NameCustomer, pattern))
                throw new Exception($"the number order {order.Id} Customer name does not exist Invalid order!");
            if (order.ListShakes.Count <= 0)
                throw new Exception($"the number order {order.Id} The customer did not select any shakes");
            else
            {
                foreach (var shakes in order.ListShakes)
                {
                    //השאלה אם הוא יודע אם זה הערך של מחיר ולא גודל
                   order.TotalPrice += (double)shakes.PriceForSize;
                }
                if(order.IsHaveCoupon)
                {
                    //איך עושים הנחה של אחוזים??
                    // order.TotalPrice = order.TotalPrice * order.DiscountsAndPromotionsForPerson;
                }
                _orders.InsertOne(order);
                Console.WriteLine($"order numner: {order.Id} is save and the total price: {order.TotalPrice}");
                return order;
            }
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

        public void Update(string id, Order order)
        {
            _orders.ReplaceOne(order => order.Id == id, order);

        }
    }
}
