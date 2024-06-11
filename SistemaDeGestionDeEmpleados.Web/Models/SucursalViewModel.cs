using SistemaDeGestionDeEmpleados.Data.EF;

namespace SistemaDeGestionDeEmpleados.Web.Models
{
    public class SucursalViewModel
    {
        public int Id { get; set; }
        public string Direccion { get; set; }

        public SucursalViewModel(Sucursal sucursal)
        {
            this.Id = sucursal.IdSucursal;
            this.Direccion = sucursal.Direccion;
        }

        public static List<SucursalViewModel> MapToModel(List<Sucursal> sucursals)
        {
            return sucursals.Select(x => new SucursalViewModel(x)).ToList();
        }
    }
}
