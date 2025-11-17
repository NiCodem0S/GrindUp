using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace GrindUp.Server.Controllers
{
    [Route("api/objective")]
    [ApiController]
    public class ObjectiveController : ControllerBase
    {
        private readonly DbContext _context;
        public ObjectiveController(DbContext context)
        {
            _context = context;
        }
    }
}
