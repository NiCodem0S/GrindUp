using GrindUp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace GrindUp.Server.Controllers
{
    [Route("api/objective")]
    [ApiController]
    public class ObjectiveController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ObjectiveController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var objectives = from obj in _context.Objectives
                join objSets in _context.ObjectiveSettings
                on obj.ObjectiveId equals objSets.ObjectiveId
                select new
                {
                        ObjectiveId = obj.ObjectiveId,
                        Title = obj.Title,
                        Description = obj.Description,
                        TargetAmount = objSets.TargetAmount,
                        DurationValue = objSets.DurationValue
                };

            return Ok(objectives);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var objective = _context.Objectives.Include(o => o.Settings).FirstOrDefault();

            if(objective == null)
            {
                return NotFound();
            }

            return Ok(objective);
        }
    }
}
