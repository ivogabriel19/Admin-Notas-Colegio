using Colegio.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Colegio.Models
{
    public class Materia
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ErrMsgs.CampoRequerido)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrMsgs.LargoErroneo)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = ErrMsgs.CampoRequerido)]
        public List<string> UnidadesTematicas { get; set; }

        public Docente Docente { get; set; }
        public int DocenteId { get; set; }
        public List<CursoMateria> CursosMateria { get; set; }
        public List<Evaluacion> Evalaciones { get; set; }
    }
}
