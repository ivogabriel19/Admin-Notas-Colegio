using Colegio.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Colegio.Models
{
    public class Tarea : Evaluacion
    {
        public DateOnly FechaAlta { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [Required(ErrorMessage = ErrMsgs.CampoRequerido)]
        public DateOnly FechaCierre { get; set; }
    }
}
