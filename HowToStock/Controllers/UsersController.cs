using howtostock_api.Context;
using HowToStock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
/*using BCrypt.Net;
*/
namespace Users.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly HowToStockContext _howtostockContext;

        public UsersController(HowToStockContext howtostockContext)
        {
            _howtostockContext = howtostockContext;
        }
        
        [HttpGet("{id:int}", Name = "GetUsers")]
        public ActionResult<User> Get(int id)
        {
            var categoria = _howtostockContext.Users?.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return categoria is null ? NotFound() : categoria;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var exs = _howtostockContext.Users?.AsNoTracking().ToList();
            return exs is null ? NotFound() : exs;
        }

        [HttpPost("Authentification")]
        public ActionResult<User> Authentification(User ex)
        {
            if (ex is null) return BadRequest();

            User usr = _howtostockContext.Users.FirstOrDefault(x => x.Mail == ex.Mail && x.Password == ex.Password);

            if (usr is null) return NotFound();

            return usr;
        }

        [HttpPost]
        public ActionResult<User> Post(User ex)
        {
            if(ex is null) return BadRequest();
            
            _howtostockContext.SaveChanges();

            return new CreatedAtRouteResult("GetUser", new { id = ex.Id, ex});
        }

        [HttpPut("{id:int}")]
        public ActionResult<User> Put(int id, User ex)
        {
            if(ex is null || ex.Id != id) return BadRequest();

            _howtostockContext.Entry<User>(ex).State = EntityState.Modified;
            _howtostockContext.SaveChanges();

            return Ok(ex);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var categoria = _howtostockContext.Users?.FirstOrDefault(c => c.Id == id);

            if(categoria is null) return NotFound();

            _howtostockContext.Users?.Remove(categoria);
            _howtostockContext.SaveChanges();

            return Ok(categoria);
        }
    }
}