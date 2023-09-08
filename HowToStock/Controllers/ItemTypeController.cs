using howtostock_api.Context;
using HowToStock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exercices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemTypeController : ControllerBase
    {
        private readonly HowToStockContext _howtostockContext;

        public ItemTypeController(HowToStockContext howtostockContext)
        {
            _howtostockContext = howtostockContext;
        }
        
        [HttpGet("{id:int}", Name = "GetItemTypes")]
        public ActionResult<ItemType> Get(int id)
        {
            var categoria = _howtostockContext.ItemType?.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return categoria is null ? NotFound() : categoria;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemType>> Get()
        {
            var exs = _howtostockContext.ItemType?.AsNoTracking().ToList();
            return exs is null ? NotFound() : exs;
        }

        [HttpPost]
        public ActionResult<ItemType> Post(ItemType ex)
        {
            if(ex is null) return BadRequest();

            _howtostockContext.ItemType?.Add(ex);
            _howtostockContext.SaveChanges();

            return new CreatedAtRouteResult("GetItemType", new { id = ex.Id, ex});
        }

        [HttpPut("{id:int}")]
        public ActionResult<ItemType> Put(int id, ItemType ex)
        {
            if(ex is null || ex.Id != id) return BadRequest();

            _howtostockContext.Entry(ex).State = EntityState.Modified;
            _howtostockContext.SaveChanges();

            return Ok(ex);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var categoria = _howtostockContext.ItemType?.FirstOrDefault(c => c.Id == id);

            if(categoria is null) return NotFound();

            _howtostockContext.ItemType?.Remove(categoria);
            _howtostockContext.SaveChanges();

            return Ok(categoria);
        }
    }
}