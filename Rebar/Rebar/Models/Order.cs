using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Rebar.Models
{
    [BsonIgnoreExtraElements]
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("nameCustomer")]
        public string NameCustomer { get; set; }

        [BsonElement("dateOrder")]
        public DateTime DateOrder { get; set; }

        [BsonElement("listOfDiscountsAndPromotions")]
        public List< DiscountsAndPromotions> ListOfDiscountsAndPromotions  { get; set; }

        [BsonElement("sumPriceShakeInList")]
        public double SumPriceShakeInList { get; set; }

        [BsonElement("listShakes")]
        public List<Shake> ListShakes { get; set; }
    }
}
