
using Microsoft.AspNetCore.Mvc;
using WebApiCalificaciones.Data;


namespace WebApiCalificaciones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradeController : ControllerBase
    {
        private readonly ILogger<GradeController> _logger;
        private readonly DataContext _context;
        public GradeController(ILogger<GradeController> logger,DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        
    }
}