using MongoDB.Driver;
using Rebar.Models;

namespace Rebar.Services
{
    public class OrderService : IOrderService
    {

        private readonly IMongoCollection<Shake> _shake;
        //פה נעשה 2 סוגיפ של גם שייק וגם הנחות ומבצעים

        public OrderService(IRebarStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _shake = database.GetCollection<Shake>(settings.OrderCollectionName);
        }
        public DiscountsAndPromotions CreateDiscountsAndPromotions(DiscountsAndPromotions discountsAndPromotions)
        {
            throw new NotImplementedException();
        }

        public Shake CreateShakeInOrder(Shake shake)
        {
            throw new NotImplementedException();
        }

        public void DeleteShake(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<DiscountsAndPromotions> GetAll()
        {
            throw new NotImplementedException();
        }

        public Shake GetShakeById(Guid shakeId)
        {
            throw new NotImplementedException();
        }

        public List<Shake> GetShakes()
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderShake(Guid id, Shake shake)
        {
            throw new NotImplementedException();
        }
    }
}
