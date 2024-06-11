using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestionDeEmpleados.Web.Models
{
    public class EmpleadoRequestViewModel
    {
        [Required(ErrorMessage = "El nombre completo es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre completo no puede exceder los 100 caracteres.")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "La Sucursal es obligatoria.")]
        public int IdSucursal { get; set; }

        public EmpleadoRequestViewModel()
        {
        }
    }
}
