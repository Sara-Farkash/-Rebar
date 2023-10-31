using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
public enum priceForSizeEnum
{
    Large=32,
    Small=28,
    Medium=24
}
namespace Rebar.Models
{

    [BsonIgnoreExtraElements]
    public class Shake
    {
        [BsonId]
       // [BsonRepresentation(BsonType.String)]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("priceForSize")]
        public priceForSizeEnum PriceForSize { get; set; }
    }
    }

