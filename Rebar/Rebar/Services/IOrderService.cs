using Rebar.Models;

namespace Rebar.Services
{
    public interface IOrderService
    {


        //DiscountsAndPromotions GetDiscountsAndPromotions();

      //  DiscountsAndPromotions CreateDiscountsAndPromotions(DiscountsAndPromotions discountsAndPromotions);
        List<Shake> GetShakes();
        Shake GetShakeById(Guid shakeId);
        Shake CreateShakeInOrder(Shake shake);
        void DeleteShake(Guid id);
        void UpdateOrderShake(Guid id,Shake shake);
    }
}
