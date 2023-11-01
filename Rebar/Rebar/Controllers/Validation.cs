using Rebar.Models;
using System.Text.RegularExpressions;

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
            if (order.ListShakes.Count > 10)
                return $"the number order {order.Id} Exceeded the amount of shakes that can be ordered!";

            string pattern = "^[A-Za-z]+$";
            if (!Regex.IsMatch(order.NameCustomer, pattern))
               return $"the number order {order.Id} Customer name does not exist Invalid order!";
            if (order.ListShakes.Count <= 0)
                return $"the number order {order.Id} The customer did not select any shakes";

            return "true";
        }

        public string validationShake(Shake shake)
        {
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
