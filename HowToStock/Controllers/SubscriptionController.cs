using howtostock_api.Context;
using HowToStock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Users.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly HowToStockContext _howtostockContext;

        public SubscriptionController(HowToStockContext howtostockContext)
        {
            _howtostockContext = howtostockContext;
        }
        
        [HttpGet("{id:int}", Name = "GetSubscriptions")]
        public ActionResult<Subscription> Get(int id)
        {
            var categoria = _howtostockContext.Subscriptions?.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return categoria is null ? NotFound() : categoria;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Subscription>> Get()
        {
            var exs = _howtostockContext.Subscriptions?.AsNoTracking().ToList();
            return exs is null ? NotFound() : exs;
        }

        [HttpPost]
        public ActionResult<Subscription> Post(Subscription ex)
        {
            if (ex is null) return BadRequest();

            _howtostockContext.SaveChanges();

            return new CreatedAtRouteResult("GetSubscription", new { id = ex.Id, ex });
        }

        [HttpPut("{id:int}")]
        public ActionResult<Subscription> Put(int id, Subscription ex)
        {
            if (ex is null || ex.Id != id) return BadRequest();

            _howtostockContext.Entry(ex).State = EntityState.Modified;
            _howtostockContext.SaveChanges();

            return Ok(ex);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var categoria = _howtostockContext.Subscriptions?.FirstOrDefault(c => c.Id == id);

            if (categoria is null) return NotFound();

            _howtostockContext.Subscriptions?.Remove(categoria);
            _howtostockContext.SaveChanges();

            return Ok(categoria);
        }
    }
}