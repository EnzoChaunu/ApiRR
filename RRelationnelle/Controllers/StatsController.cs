using Microsoft.AspNetCore.Mvc;
using RRelationnelle.Service;
using Service.Services;
using System.Threading.Tasks;

namespace APIRRelationnel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatsController : Controller
    {
        private readonly StatsService _service;

        public StatsController(StatsService service)
        {
            _service = service;
        }


        [HttpGet("StatToday")]
        public async Task<IActionResult> Getstat()
        {
            var stat = await _service.GetStat();
            if (stat.ResponseCode == 200)
            {
                return Ok(stat);
            }
            else
            {
                return BadRequest(stat);
            }
        }
    }
}
