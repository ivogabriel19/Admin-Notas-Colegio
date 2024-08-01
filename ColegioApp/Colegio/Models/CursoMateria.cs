using Colegio.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Colegio.Models
{
    public class CursoMateria
    {
        [Required(ErrorMessage = ErrMsgs.CampoRequerido)]
        [Key]
        [Display(Name = "Curso")]
        public int CursoId { get; set; }
        [Required(ErrorMessage = ErrMsgs.CampoRequerido)]
        [Key]
        [Display(Name = "Materia")]
        public int MateriaId { get; set; }
        public Curso Curso { get; set; }
        public Materia Materia { get; set; }
    }
}
