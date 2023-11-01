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
        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;  
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
            ////לפני שאנחנו מוסיפים את ההזמנה נבדוק אם אפשר להוסיף מבחנת תקינות קלט
            if (!validation.validationOrder(order).Equals("true"))
                return BadRequest(validation.validationOrder(order));


            _accountService.CreateOrder(order);
            return CreatedAtAction(nameof(Get),new { id=order.Id },order);
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Order order)
        {
            Validation validation = new Validation();
            ////לפני שאנחנו מוסיפים את ההזמנה נבדוק אם אפשר להוסיף מבחנת תקינות קלט
            if (!validation.validationOrder(order).Equals("true"))
                return BadRequest(validation.validationOrder(order));

            var existingOrder = _accountService.GetOrderById(id);
            if (existingOrder == null)
            {
                return NotFound($"order with Id={id} not found");
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
