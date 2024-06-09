using Microsoft.AspNetCore.Mvc;
using SistemaDeGestionDeEmpleados.Servicios;
using SistemaDeGestionDeEmpleados.Web.Models;
using System.Diagnostics;

namespace SistemaDeGestionDeEmpleados.Web.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoService empleadoService;

        private readonly ISucursalService sucursalService;


        public EmpleadoController(IEmpleadoService empleadoService, ISucursalService sucursalService)
        {
            this.empleadoService = empleadoService;
            this.sucursalService = sucursalService;
        }

        [HttpGet]
        public IActionResult Index(int? idSucursal)
        {
            var empleados = this.empleadoService.Obtener(idSucursal);

            return View(empleados);
        }

        [HttpGet]
        public IActionResult CrearForm()
        {
            this.ViewBag.Sucursales = this.sucursalService.ListarActivas();
            return View();
        }

        [HttpPost]
        public IActionResult Crear(EmpleadoViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View(CrearForm());
            }
            this.empleadoService.Crear(model.NombreCompleto, model.Sucursal.Id);

            return RedirectToAction("Index");
        }
    }
}
