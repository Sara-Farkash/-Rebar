using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Rebar.Models
{
    [BsonIgnoreExtraElements]
    public class DatabaseOfBranch
    {


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("listAccount")]
        public List<Account> ListAccount { get; set; }

        //public static string password { get; set; } = "jdfo8oq23u2rjfdijf";

        //public DatabaseOfBranch()
        //{
        //    Id = Guid.NewGuid().ToString();
        //}
    }
}
