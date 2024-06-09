using SistemaDeGestionDeEmpleados.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionDeEmpleados.Servicios
{
    public interface IEmpleadoService
    {
        int Crear(string nombreCompleto, int idSucursal);

        List<Empleado> Obtener(int? idSucursal);
    }
}
