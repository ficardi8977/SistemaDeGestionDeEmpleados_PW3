using SistemaDeGestionDeEmpleados.Data.EF;

namespace SistemaDeGestionDeEmpleados.Web.Models
{
    public class EmpleadoResponseViewModel
    {
        public string NombreCompleto { get; set; }

        public SucursalViewModel Sucursal { get; set; }


        public EmpleadoResponseViewModel()
        {
        }

        public EmpleadoResponseViewModel(Empleado empleado)
        {
            this.NombreCompleto = empleado.NombreCompleto;
            this.Sucursal = new SucursalViewModel(empleado.IdSucursalNavigation);
        }

        public static List<EmpleadoResponseViewModel> MapToModel(List<Empleado> empleados)
        {
            return empleados.Select(x => new EmpleadoResponseViewModel(x)).ToList();
        }
    }
}
