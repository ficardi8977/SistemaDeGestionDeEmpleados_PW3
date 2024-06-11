using Microsoft.AspNetCore.Mvc;
using SistemaDeGestionDeEmpleados.Servicios;
using SistemaDeGestionDeEmpleados.Web.Models;

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
        public IActionResult Index(int idSucursal)
        {
            this.ViewBag.Sucursales = SucursalViewModel.MapToModel(this.sucursalService.ListarActivas());
            return View(EmpleadoResponseViewModel.MapToModel(this.empleadoService.Obtener(idSucursal)));
        }

        [HttpGet]
        public IActionResult CrearForm()
        {
            this.ViewBag.Sucursales = SucursalViewModel.MapToModel(this.sucursalService.ListarActivas());
            return View();
        }

        [HttpPost]
        public IActionResult Crear(EmpleadoRequestViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View(CrearForm());
            }
            this.empleadoService.Crear(model.NombreCompleto, model.IdSucursal);

            return RedirectToAction("Index");
        }
    }
}
