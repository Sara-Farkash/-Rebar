using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public enum DiscountsAndPromotions
{
    soldier = 30,
    teacher = 30,
    disabled = 42,
    student = 13,
    stateEmployee = 24,
    club = 15
}
namespace Rebar.Models
{

    [BsonIgnoreExtraElements]
    public class Order
    {
        [BsonId]
        // [BsonRepresentation(BsonType.String)]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        [BsonElement("nameCustomer")]
        public string NameCustomer { get; set; }

        [BsonElement("dateOrder")]
        public DateTime DateOrder { get; set; }

        [BsonElement("listOfDiscountsAndPromotions")]
        public DiscountsAndPromotions DiscountsAndPromotionsForPerson { get; set; }

        public bool IsHaveCoupon { get; set; }

        [BsonElement("listShakes")]
        public List<Shake> ListShakes { get; set; }

        [BsonElement("totalPrice")]
        public double TotalPrice { get; set; }
        //enum
        //אפשר למחוק את המחלקה עצמה ולעשות אינם להחזיר אותו לטבלה כמחרוזת
    }
}
