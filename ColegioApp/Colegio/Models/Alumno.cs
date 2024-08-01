using Colegio.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Colegio.Models
{
    public class Alumno : Persona
    {
        public Curso Curso { get; set; }
        public int CursoId { get; set; }

        public List<Evaluacion> Evaluaciones { get; set; }
    }
}
