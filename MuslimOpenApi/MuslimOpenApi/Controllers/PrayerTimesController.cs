using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MuslimOpenApi.Data;
using MuslimOpenApi.Helpers;

namespace MuslimOpenApi.Controllers
{
    [ApiController]
    public class PrayerTimesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PrayerTimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("prayertimes")]
        public IActionResult Get()
        {
            var abc = _context.PrayerTimes.Count();
            var prayerTimeObject = _context.PrayerTimes.Where(x => x.Date.Contains(DateHelper.GetTodaysDate())).ToList();

            if (!prayerTimeObject.Any())
            {
                return NotFound();
            }

            return Ok(prayerTimeObject);
        }

        [HttpGet]
        [Route("prayertimes/{month}/{day}")]
        public string Get([FromRoute] int month, int day)
        {
            return month.ToString() + " " + day.ToString();
        }
    }
}
