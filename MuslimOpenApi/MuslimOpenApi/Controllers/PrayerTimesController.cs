using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MuslimOpenApi.Data;

namespace MuslimOpenApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrayerTimesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PrayerTimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PrayerTimes
        [HttpGet]
        public IActionResult Get()
        {
            //return new string[] { "value1", "value2" };
            var abc = _context.PrayerTimes.Count();
            var prayerTimeObject = _context.PrayerTimes.Where(x => x.Date.Contains("01-01-2020")).ToList();

            if (!prayerTimeObject.Any())
            {
                return NotFound();
            }

            return Ok(prayerTimeObject);
        }

        /*
        // GET: api/PrayerTimes/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PrayerTimes
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/PrayerTimes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
