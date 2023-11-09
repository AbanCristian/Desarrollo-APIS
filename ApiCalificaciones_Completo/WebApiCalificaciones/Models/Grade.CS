using WebApiCalificaiones.Models;

namespace WebApiCalificaciones.Models;

public class Grade
{
        public Grade() // Constructor para inicializar la propiedad Calificaciones, revisar si provoca alguno problema en el codigo
        {
            Student grade = new Student();
            PuntajeCalificacion = grade.Calificaciones;
            Id = grade.Id;
        }
        public int Id {get; set;}
        public string? NombreAsignatura {get; set;}
        public double PuntajeCalificacion {get; set;}

}
