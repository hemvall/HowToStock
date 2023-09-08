using howtostock_api.Context;
using HowToStock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Item.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly HowToStockContext _howtostockContext;

        public StateController(HowToStockContext howtostockContext)
        {
            _howtostockContext = howtostockContext;
        }
        
        [HttpGet("{id:int}", Name = "GetStates")]
        public ActionResult<State> Get(int id)
        {
            var categoria = _howtostockContext.State?.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return categoria is null ? NotFound() : categoria;
        }

        [HttpGet]
        public ActionResult<IEnumerable<State>> Get()
        {
            var exs = _howtostockContext.State?.AsNoTracking().ToList();
            return exs is null ? NotFound() : exs;
        }

        [HttpPost]
        public ActionResult<State> Post(State ex)
        {
            if(ex is null) return BadRequest();

            _howtostockContext.State?.Add(ex);
            _howtostockContext.SaveChanges();

            return new CreatedAtRouteResult("GetSize", new { id = ex.Id, ex});
        }

        [HttpPut("{id:int}")]
        public ActionResult<State> Put(int id, State ex)
        {
            if(ex is null || ex.Id != id) return BadRequest();

            _howtostockContext.Entry(ex).State = EntityState.Modified;
            _howtostockContext.SaveChanges();

            return Ok(ex);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var categoria = _howtostockContext.State?.FirstOrDefault(c => c.Id == id);

            if(categoria is null) return NotFound();

            _howtostockContext.State?.Remove(categoria);
            _howtostockContext.SaveChanges();

            return Ok(categoria);
        }
    }
}