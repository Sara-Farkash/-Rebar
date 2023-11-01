using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Rebar.Models
{
    [BsonIgnoreExtraElements]
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("lumpSum")]
        public double LumpSum { get; set; }

        [BsonElement("listOrders")]
        public List<Order> ListOrders { get; set; }
    }
}
