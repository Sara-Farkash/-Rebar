using Microsoft.AspNetCore.Mvc;
using Rebar.Models;
using Rebar.Services;
using System.Runtime.InteropServices;

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
            //Before returning everything, check if it's a manager
            Console.WriteLine("write the passpord");
            string pws = Console.ReadLine();
            if (!pws.Equals("43wjerfpgjf340p9u"))
                return BadRequest("wrong password");
            return databaseOfBranchService.GetAccounts();
        }

        [HttpPost]
        public ActionResult<Account> Post([FromBody] Account account)
        {
            //Only an manager can close a checkout, so we will check if it is an manager!!
            Console.WriteLine("write the passpord");
            string pws=Console.ReadLine();
            if(!pws.Equals("43wjerfpgjf340p9u")) 
                return BadRequest("wrong password");
            databaseOfBranchService.Create(account);
            return CreatedAtAction(nameof(Get), new { id = account.Id }, account);
        }      
    }
}
