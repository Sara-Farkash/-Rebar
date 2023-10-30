using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
namespace Rebar.Models
{

    [BsonIgnoreExtraElements]
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
        public PriceForSize PriceForSize { get; set; }
    }
        public record PriceForSize
        {
            public double Large { get; init; }
            public double Medium { get; init; }
            public double Small { get; init; }

            public PriceForSize(double small, double medium, double large)
            {
                Small = small;
                Medium = medium;
                Large = large;
            }

        }
    }

