using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using WeatherArchivesDisplay.Controllers.Utils;
using WeatherArchivesDisplay.DataAccess;

namespace WeatherArchivesDisplay.Controllers
{
    public class ViewPageController : Controller
    {
        private readonly Db _db;

        public ViewPageController(Db db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<LogEntry>>> GetLogEntries([FromBody] DateTimeFilters filters)
        {
            try
            {
                var entries = await _db.LogEntries.Where(d => d.DateTime >= filters.StartDateTime && d.DateTime <= filters.EndDateTime).OrderBy(d => d.DateTime).ToListAsync();

                return Ok(entries);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
