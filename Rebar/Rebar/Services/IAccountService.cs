using Rebar.Models;

namespace Rebar.Services
{
    public interface IAccountService
    {
        //מביא את כל ההזמנות
        List <Order> GetAllOrders ();
        //מביא הזמנה לפי שם יחודי
        Order GetOrderById(string id);
        //יוצר הזמנה חדשה...
        //ומוסיף אותה לתוך המערך
        //ומוסיף את הסכום של ההזמנה לתוך הסכום של הקופה
        Order CreateOrder (Order order);
        //מעדכן הזמנה
        void Update (string id,Order order);
        //מוחק הזמנה
        void DeleteOrder (string Id);
        

    }
}
