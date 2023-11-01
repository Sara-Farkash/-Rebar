using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

       
        //[System.Text.Json.Serialization.JsonConverter(typeof(StringEnumConverter))]  // JSON.Net
        [BsonElement("priceForSize")]
        [BsonRepresentation(BsonType.String)]         // Mongo
        public priceForSizeEnum? PriceForSize { get; set; }

        //public Shake()
        //{
        //    Id= Guid.NewGuid().ToString();

        //}

    }
    }

