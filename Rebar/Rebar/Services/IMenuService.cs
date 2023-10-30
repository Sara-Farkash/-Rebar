using Rebar.Models;

namespace Rebar.Services
{
    public interface IMenuService
    {
        List<Shake> GetShakes();
        Shake GetShakeById(Guid id);
        Shake Create(Shake shake);
        void Update(Guid id,Shake shake);
        void Delete(Guid id);
    }
}
