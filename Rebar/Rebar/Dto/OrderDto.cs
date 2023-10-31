using Rebar.Models;

namespace Rebar.Dto
{
    public class OrderDto
    {
        public string Name { get; set; }
        public List<Shake> ListShakes { get; set; }
    }
}
