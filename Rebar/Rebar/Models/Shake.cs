using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Rebar.Models
{
    public enum EnumPriceForSize
    {
        L=32,M=28,S=23
    }
    public class Shake
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("priceForSize")]
        public EnumPriceForSize PriceForSize { get; set; }




    }
}
