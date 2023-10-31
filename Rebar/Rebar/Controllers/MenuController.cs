using Microsoft.AspNetCore.Mvc;
using Rebar.Models;
using Rebar.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rebar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            this._menuService = menuService;
        }
        // GET: api/<MenuController>
        [HttpGet]
        public ActionResult<List<Shake>> Get()
        {
            return _menuService.GetShakes();
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public ActionResult<Shake> Get(string id)
        {
           var shake= _menuService.GetShakeById(id);
            if(shake == null) { NotFound($"Shake with Id={id} not found"); }
            return shake;
        }

        // POST api/<MenuController>
        [HttpPost]
        public ActionResult<Shake> Post([FromBody] Shake shake)
        {
            _menuService.Create(shake);
            return CreatedAtAction(nameof(Get), new { id = shake.Id }, shake);
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Shake shake)
        {
            var existingShake = _menuService.GetShakeById(id);
            if (existingShake == null)
            {
                return NotFound($"Shake with Id={id} not found");
            }
            _menuService.Update(id, shake);
            return NoContent();
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var shake=_menuService.GetShakeById(id);
            if(shake == null) { NotFound($"Shake with Id={id} not found"); }
            _menuService.Delete(shake.Id);
            return Ok($"Shake with Id ={id} deleted");
        }
    }
}
