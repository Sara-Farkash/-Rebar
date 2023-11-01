using Rebar.Models;

namespace Rebar.Controllers
{
    public class Validation
    {

        public  string validationOrder(Order order)
        {
            if (string.IsNullOrEmpty(order.NameCustomer))
            {
                return "NameCustomer must not be empty.";
            }

            if (!DateTime.TryParse(order.DateOrder.ToString(), out _))
            {
                return "Invalid DateOrder format.";
            }
            if (!Enum.IsDefined(typeof(DiscountsAndPromotions), order.DiscountsAndPromotionsForPerson))
            {
                return "Invalid DiscountsAndPromotionsForPerson value.";
            }
            if (order.ListShakes == null || order.ListShakes.Count == 0)
            {
                return "At least one Shake must be in the list.";
            }

            return "true";
        }

        public string validationShake(Shake shake)
        {
            //if (_menuService.GetShakes() == null || _menuService.GetShakes().Count == 0)
            //{
            //    return "The ShakesList must not be empty.";
            //}
            if (string.IsNullOrEmpty(shake.Name))
            {
                return "Name must not be empty.";
            }
            if (!Enum.IsDefined(typeof(priceForSizeEnum), shake.PriceForSize))
            {
                return "Invalid PriceForSize value.";
            }
            if (string.IsNullOrEmpty(shake.Description))
            {
                return "Description must not be empty.";
            }
            return "true";
        }
    }
}
