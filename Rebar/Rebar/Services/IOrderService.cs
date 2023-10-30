using Rebar.Models;

namespace Rebar.Services
{
    public interface IOrderService
    {
        List<DiscountsAndPromotions> GetAll();
        DiscountsAndPromotions CreateDiscountsAndPromotions(DiscountsAndPromotions discountsAndPromotions);
        //void DeleteDiscountsAndPromotions()
        List<Shake> GetShakes();
        Shake GetShakeById(Guid shakeId);
        Shake CreateShakeInOrder(Shake shake);
        void DeleteShake(Guid id);
        void UpdateOrderShake(Guid id,Shake shake);
    }
}
