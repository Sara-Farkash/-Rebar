using MongoDB.Driver;
using Rebar.Models;

namespace Rebar.Services
{
    public class OrderService : IOrderService
    {

        private readonly IMongoCollection<Shake> _shake;
        //פה נעשה 2 סוגיפ של גם שייק וגם הנחות ומבצעים
        //private readonly 

        public OrderService(IRebarStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _shake = database.GetCollection<Shake>(settings.OrderCollectionName);
        }

        public Shake CreateShakeInOrder(Shake shake)
        {
           _shake.InsertOne(shake);
            return shake;
        }

        public void DeleteShake(string id)
        {
            _shake.DeleteOne(shake => shake.Id == id);
        }


        //public DiscountsAndPromotions GetDiscountsAndPromotions()
        //{
        // //   return _.Find(shakes => true).ToList();
        //}

        public Shake GetShakeById(string shakeId)
        {
            return _shake.Find(shake => shake.Id == shakeId).FirstOrDefault();
        }

        public List<Shake> GetShakes()
        {
            return _shake.Find(shakes => true).ToList();
        }

        public void UpdateOrderShake(string id, Shake shake)
        {
            throw new NotImplementedException();
        }
    }
}
