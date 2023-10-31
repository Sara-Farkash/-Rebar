using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Rebar.Models
{
    [BsonIgnoreExtraElements]
    public class DatabaseOfBranch
    {

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        [BsonElement("listAccount")]
        public List<Account> ListAccount { get; set; }
    }
}
