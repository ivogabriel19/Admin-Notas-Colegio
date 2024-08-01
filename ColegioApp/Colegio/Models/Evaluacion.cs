using Colegio.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Colegio.Models
{
    public class Evaluacion
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ErrMsgs.CampoRequerido)]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrMsgs.LargoErroneo)]
        public string Tema { get; set; }
        public float Nota { get; set; }
        public int MateriaId { get; set; }
        public int AlumnoId { get; set; }
    }
}
