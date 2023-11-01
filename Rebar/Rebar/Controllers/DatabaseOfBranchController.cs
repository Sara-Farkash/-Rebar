using Microsoft.AspNetCore.Mvc;
using Rebar.Models;
using Rebar.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rebar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseOfBranchController : ControllerBase
    {
        private readonly IDatabaseOfBranchService  databaseOfBranchService;
        public DatabaseOfBranchController(IDatabaseOfBranchService databaseOfBranchService)
        {
            this.databaseOfBranchService = databaseOfBranchService;
        }
        // GET: api/<DatabaseOfBranchController>
        [HttpGet]
        public ActionResult<List<Account>> Get()
        {
            //לפני שמחזירים את הכל בודקים האם זה מנהל
            Console.WriteLine("write the passpord");
            string pws = Console.ReadLine();
            if (!pws.Equals("43wjerfpgjf340p9u"))
                return BadRequest("wrong password");
            return databaseOfBranchService.GetAccounts();
        }

        // GET api/<DatabaseOfBranchController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<DatabaseOfBranchController>

        [HttpPost]
        public ActionResult<Account> Post([FromBody] Account account)
        {
            Console.WriteLine("write the passpord");
            string pws=Console.ReadLine();
            if(!pws.Equals("43wjerfpgjf340p9u")) 
                return BadRequest("wrong password");
            //לפני שיוצרים חשבון בודקים האם הכל בסדר
            databaseOfBranchService.Create(account);
            return CreatedAtAction(nameof(Get), new { id = account.Id }, account);
        }      
    }
}
