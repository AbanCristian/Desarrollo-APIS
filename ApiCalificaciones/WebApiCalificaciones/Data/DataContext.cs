
using WebApiCalificaciones.Models;
using Microsoft.EntityFrameworkCore;
using WebApiCalificaiones.Models;


namespace WebApiCalificaciones.Data;
public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
        
    }
    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }

} 
