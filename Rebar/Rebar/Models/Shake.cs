using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
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
        public PriceForSize PriceForSize { get; set; }
    }
    public record PriceForSize
    {
        public int Large { get; init; }
        public int Medium { get; init; }
        public int Small { get; init; }

    }
    }

