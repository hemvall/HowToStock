using howtostock_api.Context;
using HowToStock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities;

namespace Exercices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly HowToStockContext _howtostockContext;

        public ItemsController(HowToStockContext howtostockContext)
        {
            _howtostockContext = howtostockContext;
        }
        
        [HttpGet("{id:int}", Name = "GetItems")]
        public ActionResult<Items> Get(int id)
        {
            var categoria = _howtostockContext.Item?.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return categoria is null ? NotFound() : categoria;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Items>> Get()
        {
            var exs = _howtostockContext.Item?.AsNoTracking().ToList();
            return exs is null ? NotFound() : exs;
        }

        [HttpPost]
        public ActionResult<Items> Post(Items ex)
        {
            if(ex is null) return BadRequest();

            _howtostockContext.Item?.Add(ex);
            _howtostockContext.SaveChanges();

            return new CreatedAtRouteResult("PostItems", new { id = ex.Id, ex});
        }

        [HttpPut("{id:int}")]
        public ActionResult<Items> Put(int id, Items ex)
        {
            if(ex is null || ex.Id != id) return BadRequest();

            _howtostockContext.Entry<Items>(ex).State = EntityState.Modified;
            _howtostockContext.SaveChanges();

            return Ok(ex);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var categoria = _howtostockContext.Item?.FirstOrDefault(c => c.Id == id);

            if(categoria is null) return NotFound();

            _howtostockContext.Item?.Remove(categoria);
            _howtostockContext.SaveChanges();

            return Ok(categoria);
        }
    }
}