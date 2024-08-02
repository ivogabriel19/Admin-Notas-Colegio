using Colegio.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Colegio.Models
{
    public class Persona
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ErrMsgs.CampoRequerido)]
        [StringLength(12,MinimumLength =4,ErrorMessage =ErrMsgs.LargoErroneo)]
        [RegularExpression(@"[a-zA-Z0-9]*", ErrorMessage = ErrMsgs.CaracteresNoPermitidos)]
        public string Legajo { get; set; }
        [Required(ErrorMessage = ErrMsgs.CampoRequerido)]
        [StringLength(30, MinimumLength = 2, ErrorMessage = ErrMsgs.LargoErroneo)]
        [RegularExpression(@"[a-zA-Z ]*", ErrorMessage = ErrMsgs.CaracteresNoPermitidos)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = ErrMsgs.CampoRequerido)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = ErrMsgs.LargoErroneo)]
        [Display(Name = "Correo Electronico")]
        [EmailAddress(ErrorMessage = ErrMsgs.NotValid)]
        public string Mail { get; set; }
        [Required(ErrorMessage = ErrMsgs.CampoRequerido)]
        [Range(1000000,99999999,ErrorMessage = ErrMsgs.FueraDeRango)]
        [Display(Name = "Documento")]
        public int Dni {get; set; }
        public string Foto { get; set; }
    }
}
