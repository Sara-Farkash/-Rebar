using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Rebar.Models
{
    public class Menu
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("shakesList")]
        public List<Shake>ShakesList { get; set; }
    }
}
