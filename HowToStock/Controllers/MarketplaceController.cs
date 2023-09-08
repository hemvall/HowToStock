using howtostock_api.Context;
using HowToStock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Languages.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MarketplaceController : ControllerBase
    {
        private readonly HowToStockContext _howtostockContext;

        public MarketplaceController(HowToStockContext howtostockContext)
        {
            _howtostockContext = howtostockContext;
        }
        
        [HttpGet("{id:int}", Name = "GetMarketplaces")]
        public ActionResult<Marketplace> Get(int id)
        {
            var perf = _howtostockContext.Marketplace?.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return perf is null ? NotFound() : perf;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Marketplace>> Get()
        {
            var perf = _howtostockContext.Marketplace?.AsNoTracking().ToList();
            return perf is null ? NotFound() : perf;
        }

        [HttpPost]
        public ActionResult<Marketplace> Post(Marketplace perf)
        {
            if(perf is null) return BadRequest();

            _howtostockContext.Marketplace?.Add(perf);
            _howtostockContext.SaveChanges();

            return new CreatedAtRouteResult("GetMarketplace", new { id = perf.Id, perf});
        }

        [HttpPut("{id:int}")]
        public ActionResult<Marketplace> Put(int id, Marketplace perf)
        {
            if(perf is null || perf.Id != id) return BadRequest();

            _howtostockContext.Entry(perf).State = EntityState.Modified;
            _howtostockContext.SaveChanges();

            return Ok(perf);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var perf = _howtostockContext.Marketplace?.FirstOrDefault(c => c.Id == id);

            if(perf is null) return NotFound();

            _howtostockContext.Marketplace?.Remove(perf);
            _howtostockContext.SaveChanges();

            return Ok(perf);
        }
    }
}