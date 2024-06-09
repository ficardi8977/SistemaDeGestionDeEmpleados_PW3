using SistemaDeGestionDeEmpleados.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionDeEmpleados.Servicios
{
    public class SucursalService : ISucursalService
    {
        SistemaDeGestionDeEmpleadosContext context;

        public SucursalService(SistemaDeGestionDeEmpleadosContext context)
        {
            this.context = context;
        }

        public List<Sucursal> ListarActivas()
        {
            return this.context.Sucursals.Where(s => !s.Eliminada).ToList();
        }
    }
}
