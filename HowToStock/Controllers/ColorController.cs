using howtostock_api.Context;
using HowToStock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Item.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly HowToStockContext _howtostockContext;

        public ColorController(HowToStockContext howtostockContext)
        {
            _howtostockContext = howtostockContext;
        }
        
        [HttpGet("{id:int}", Name = "GetColors")]
        public ActionResult<Color> Get(int id)
        {
            var categoria = _howtostockContext.Color?.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return categoria is null ? NotFound() : categoria;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Color>> Get()
        {
            var exs = _howtostockContext.Color?.AsNoTracking().ToList();
            return exs is null ? NotFound() : exs;
        }

        [HttpPost]
        public ActionResult<Color> Post(Color ex)
        {
            if(ex is null) return BadRequest();

            _howtostockContext.Color?.Add(ex);
            _howtostockContext.SaveChanges();

            return new CreatedAtRouteResult("GetColor", new { id = ex.Id, ex});
        }

        [HttpPut("{id:int}")]
        public ActionResult<Color> Put(int id, Color ex)
        {
            if(ex is null || ex.Id != id) return BadRequest();

            _howtostockContext.Entry(ex).State = EntityState.Modified;
            _howtostockContext.SaveChanges();

            return Ok(ex);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var categoria = _howtostockContext.Color?.FirstOrDefault(c => c.Id == id);

            if(categoria is null) return NotFound();

            _howtostockContext.Color?.Remove(categoria);
            _howtostockContext.SaveChanges();

            return Ok(categoria);
        }
    }
}