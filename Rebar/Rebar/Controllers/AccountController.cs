using Microsoft.AspNetCore.Mvc;
using Rebar.Models;
using Rebar.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rebar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMenuService menuService;

        public AccountController(IAccountService accountService, IMenuService menuService)
        {
            this._accountService = accountService;  
            this.menuService = menuService;
        }
        // GET: api/<AccountController>
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return _accountService.GetAllOrders();
        }
        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(string id)
        {
            var order = _accountService.GetOrderById(id);
            if (order == null) { NotFound($"Order with Id={id} not found"); }
            return order;
        }
        // POST api/<AccountController>
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            Validation validation= new Validation();
            ////Before we add the order we will check if it is possible to add an input integrity test
            if (!validation.validationOrder(order).Equals("true"))
            return BadRequest(validation.validationOrder(order));
            foreach(Shake shake in order.ListShakes)
            {
                Shake shake1 = menuService.GetShakeById(shake.Id);
                if(shake1==null){
                    return BadRequest("This shake is not on the menu!!!");
                }
            }
            _accountService.CreateOrder(order);
            return CreatedAtAction(nameof(Get),new { id=order.Id },order);
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Order order)
        {
            Validation validation = new Validation();
            ////Before we add the order we will check if it is possible to add an input integrity test
            if (!validation.validationOrder(order).Equals("true"))
            return BadRequest(validation.validationOrder(order));
            var existingOrder = _accountService.GetOrderById(id);
            if (existingOrder == null)
            {
                return NotFound($"order with Id={id} not found");
            }
            foreach (Shake shake in order.ListShakes)
            {
                Shake shake1 = menuService.GetShakeById(shake.Id);
                if (shake1 == null)
                {
                    return BadRequest("This shake is not on the menu!!!");
                }
            }
            _accountService.Update(id, order);
            return NoContent();
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var order = _accountService.GetOrderById(id);
            if (order == null) { NotFound($"order with Id={id} not found"); }
            _accountService.DeleteOrder(order.Id);
            return Ok($"order with Id ={id} deleted");
        }      

    }
}
