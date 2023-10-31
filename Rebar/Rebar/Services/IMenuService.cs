using Rebar.Models;

namespace Rebar.Services
{
    public interface IMenuService
    {
        List<Shake> GetShakes();
        Shake GetShakeById(string id);
        Shake Create(Shake shake);
        void Update(string id,Shake shake);
        void Delete(string id);
    }
}
