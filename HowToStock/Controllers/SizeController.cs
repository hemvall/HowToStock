using howtostock_api.Context;
using HowToStock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Item.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly HowToStockContext _howtostockContext;

        public SizeController(HowToStockContext howtostockContext)
        {
            _howtostockContext = howtostockContext;
        }
        
        [HttpGet("{id:int}", Name = "GetSizes")]
        public ActionResult<Size> Get(int id)
        {
            var categoria = _howtostockContext.Size?.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return categoria is null ? NotFound() : categoria;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Size>> Get()
        {
            var exs = _howtostockContext.Size?.AsNoTracking().ToList();
            return exs is null ? NotFound() : exs;
        }

        [HttpPost]
        public ActionResult<Size> Post(Size ex)
        {
            if(ex is null) return BadRequest();

            _howtostockContext.Size?.Add(ex);
            _howtostockContext.SaveChanges();

            return new CreatedAtRouteResult("GetSize", new { id = ex.Id, ex});
        }

        [HttpPut("{id:int}")]
        public ActionResult<Size> Put(int id, Size ex)
        {
            if(ex is null || ex.Id != id) return BadRequest();

            _howtostockContext.Entry(ex).State = EntityState.Modified;
            _howtostockContext.SaveChanges();

            return Ok(ex);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var categoria = _howtostockContext.Size?.FirstOrDefault(c => c.Id == id);

            if(categoria is null) return NotFound();

            _howtostockContext.Size?.Remove(categoria);
            _howtostockContext.SaveChanges();

            return Ok(categoria);
        }
    }
}