using Colegio.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Colegio.Models
{
    public class Examen : Evaluacion
    {
        [Required(ErrorMessage = ErrMsgs.CampoRequerido)]
        public DateOnly Fecha {get; set; }
    }
}
