using howtostock_api.Context;
using HowToStock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Languages.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly HowToStockContext _howtostockContext;

        public LanguagesController(HowToStockContext howtostockContext)
        {
            _howtostockContext = howtostockContext;
        }
        
        [HttpGet("{id:int}", Name = "GetPerformances")]
        public ActionResult<Language> Get(int id)
        {
            var perf = _howtostockContext.Languages?.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return perf is null ? NotFound() : perf;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Language>> Get()
        {
            var perf = _howtostockContext.Languages?.AsNoTracking().ToList();
            return perf is null ? NotFound() : perf;
        }

        [HttpPost]
        public ActionResult<Language> Post(Language perf)
        {
            if(perf is null) return BadRequest();

            _howtostockContext.Languages?.Add(perf);
            _howtostockContext.SaveChanges();

            return new CreatedAtRouteResult("GetLanguage", new { id = perf.Id, perf});
        }

        [HttpPut("{id:int}")]
        public ActionResult<Language> Put(int id, Language perf)
        {
            if(perf is null || perf.Id != id) return BadRequest();

            _howtostockContext.Entry(perf).State = EntityState.Modified;
            _howtostockContext.SaveChanges();

            return Ok(perf);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var perf = _howtostockContext.Languages?.FirstOrDefault(c => c.Id == id);

            if(perf is null) return NotFound();

            _howtostockContext.Languages?.Remove(perf);
            _howtostockContext.SaveChanges();

            return Ok(perf);
        }
    }
}