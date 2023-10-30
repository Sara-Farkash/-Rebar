using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Rebar.Models
{
    
    public class DiscountsAndPromotions
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.String)]
        //public Guid Id { get; set; }

        //[BsonElement("description")]
        public string Description { get; set; }

        //[BsonElement("discountPercentage")]
        public double DiscountPercentage { get; set; }
    
    }
}
