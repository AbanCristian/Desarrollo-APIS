
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCalificaciones.Data;
using WebApiCalificaciones.Models;
using WebApiCalificaiones.Models;

namespace WebApiCalificaciones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;  
        private readonly DataContext _context;
        public StudentController(ILogger<StudentController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        
        }
        // Metodo que obtiene a todos los estudiantes
        [HttpGet(Name ="GetStudent")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        //Metodo que obtiene a un estudiante por el Id (Reparar, no jala)

        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> GetStudentForId(int id)
        {
            var student = await _context.Grades.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return student;
        }
       

        // Metodo que muestra un estudiante 
        [HttpPost]
        public async Task<ActionResult<Student>> Post(Student student)
        {
            _context.Add(student);
           await _context.SaveChangesAsync();

           return new CreatedAtRouteResult("GetStudent", new {id = student.Id}, student);
        }

        // Metodo para actualizar la informacion por medio del ID
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }

        
    }
    
}