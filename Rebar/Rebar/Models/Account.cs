using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Rebar.Models
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("lumpSum")]
        public double LumpSum { get; set; }

        [BsonElement("listOrders")]
        public List<Order> ListOrders { get; set; }
    }
}
