using Rebar.Models;
using MongoDB.Driver;
namespace Rebar.Services
{
    public class MenuService : IMenuService
    {
        //private readonly IMongoCollection<Menu> _menus;
        private readonly IMongoCollection<Shake>_shake;

        public MenuService(IRebarStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
          var database= mongoClient.GetDatabase(settings.DatabaseName);
            //_menus=  database.GetCollection<Menu>(settings.MenuCollectionName);
            _shake = database.GetCollection<Shake>(settings.MenuCollectionName);
        }
        public Shake Create(Shake shake)
        {
            _shake.InsertOne(shake);
            return shake;
        }

        public void Delete(string id)
        {
           _shake.DeleteOne(shake => shake.Id == id);

        }

        public Shake GetShakeById(string id)
        {
            return _shake.Find(shake => shake.Id == id).FirstOrDefault();

        }

        public List<Shake> GetShakes()
        {
          return  _shake.Find(shakes =>true).ToList();

        }

        public void Update(string id, Shake shake)
        {
            _shake.ReplaceOne(shake => shake.Id == id,shake);
        }
    }
}
