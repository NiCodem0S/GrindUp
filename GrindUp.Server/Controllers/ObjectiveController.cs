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
            var objectives = _context.Objectives.ToList();

            return Ok(objectives);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var objective = _context.Objectives.Find(id);

            if(objective == null)
            {
                return NotFound();
            }

            return Ok(objective);
        }
    }
}
