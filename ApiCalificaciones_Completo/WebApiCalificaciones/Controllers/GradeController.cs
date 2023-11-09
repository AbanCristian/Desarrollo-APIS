
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCalificaciones.Data;
using WebApiCalificaciones.Models;


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

        //Metodo que devuelve una lista de las calificaciones registradas
        [HttpGet(Name ="GetGrades")]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGrades()
        {
            return await _context.Grades.ToArrayAsync();
        }

        //Metodo que obtiene un calificacion por el Id (Reparar, no jala)

        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> GetGradeForId(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }

            return grade;
        }
       

        // Metodo que introduce una nuev calificacion
        [HttpPost]
        public async Task<ActionResult<Grade>> Post(Grade grade)
        {
            _context.Add(grade);
           await _context.SaveChangesAsync();

           return new CreatedAtRouteResult("GetStudent", new {id = grade.Id}, grade);
        }

        // Metodo para actualizar la informacion por medio del ID
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,Grade grade)
        {
            if (id != grade.Id)
            {
                return BadRequest();
            }

            _context.Entry(grade).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Metodo para eliminar alguna calificacion por medio del  ID
        [HttpDelete("{id}")]
        public async Task<ActionResult<Grade>> Delete(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }

            _context.Remove(grade);
            await _context.SaveChangesAsync();
            return grade;
        }
        
    }
}