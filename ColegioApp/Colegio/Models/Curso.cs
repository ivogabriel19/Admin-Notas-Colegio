using Colegio.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Colegio.Models
{
    public class Curso
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ErrMsgs.CampoRequerido)]
        [StringLength(10, MinimumLength = 3, ErrorMessage = ErrMsgs.LargoErroneo)]
        [Display(Name = "Curso")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = ErrMsgs.CampoRequerido)]
        [StringLength(10, MinimumLength = 2, ErrorMessage = ErrMsgs.LargoErroneo)]
        [Display(Name = "Ciclo lectivo")]
        public string Ciclo { get; set; }

        public List<Alumno> Alumnos { get; set; }

        public List<CursoMateria> CursoMaterias { get; set; }
    }
}
