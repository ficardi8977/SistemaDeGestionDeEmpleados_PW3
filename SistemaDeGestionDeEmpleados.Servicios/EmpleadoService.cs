using Microsoft.EntityFrameworkCore;
using SistemaDeGestionDeEmpleados.Data.EF;

namespace SistemaDeGestionDeEmpleados.Servicios
{
    public class EmpleadoService : IEmpleadoService
    {
        SistemaDeGestionDeEmpleadosContext ctx;

        public EmpleadoService(SistemaDeGestionDeEmpleadosContext ctx) 
        { 
            this.ctx = ctx;
        }

        public int Crear(string nombreCompleto, int idSucursal)
        {
           var empleadoNuevo = new Empleado();

            empleadoNuevo.NombreCompleto = nombreCompleto;
            empleadoNuevo.IdSucursal = idSucursal;

            this.ctx.Empleados.Add(empleadoNuevo);

            this.ctx.SaveChanges();

            return empleadoNuevo.IdEmpleado;
        }

        public List<Empleado> Obtener(int idSucursal)
        {
            
            if (idSucursal == 0)
            {
                return this.ctx.Empleados.Include(x => x.IdSucursalNavigation).ToList();
            }
            return this.ctx.Empleados.Where(e => (e.IdSucursal.Equals(idSucursal))).ToList();
        }
    }
}
