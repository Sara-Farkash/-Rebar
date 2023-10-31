using Rebar.Models;

namespace Rebar.Services
{
    public interface IOrderService
    {


        //DiscountsAndPromotions GetDiscountsAndPromotions();

      //  DiscountsAndPromotions CreateDiscountsAndPromotions(DiscountsAndPromotions discountsAndPromotions);
        List<Shake> GetShakes();
        Shake GetShakeById(string shakeId);
        Shake CreateShakeInOrder(Shake shake);
        void DeleteShake(string id);
        void UpdateOrderShake(string id,Shake shake);
    }
}
