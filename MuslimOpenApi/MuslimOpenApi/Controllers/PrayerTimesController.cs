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
            var prayerTimeObject = _context.PrayerTimes.Where(x => x.Date.Contains(DateHelper.GetTodaysDate())).ToList();

            if (!prayerTimeObject.Any())
            {
                return NotFound();
            }

            return Ok(prayerTimeObject);
        }

        [HttpGet]
        [Route("prayertimes/{month}/{day}")]
        public IActionResult Get([FromRoute] int month, int day)
        {
            if (!DateHelper.IsMonthValid(month))
            {
                return NotFound();
            }
            
            if(DateHelper.IsDayValid(day, month))
            {
                var prayerTimeObject = _context.PrayerTimes.Where(x => x.Date.Contains(DateHelper.CreateDate(day, month))).ToList();
                return Ok(prayerTimeObject);
            }

            return NotFound();
        }
    }
}
