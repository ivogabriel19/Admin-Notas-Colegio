using Colegio.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Colegio.Models
{
    public class Docente : Persona
    {
        public List<Materia> Materias { get; set; }
    }
}
