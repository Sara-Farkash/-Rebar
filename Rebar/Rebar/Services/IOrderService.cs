using Rebar.Models;

namespace Rebar.Services
{
    public interface IOrderService
    {

        //מחזיר את כל השייקים שהוזמנו
        List<Shake> GetShakes();
        //מקבל שייק להזמין  
        Shake CreateShakeInOrder(Shake shake);
       //מוחק שייק מתוך ההזמנה
        void DeleteShake(string id);
        //מעדכן שייק בהזמנה
        void UpdateOrderShake(string id,Shake shake);

        Shake GetShakeById(string shakeId);
    }
}
