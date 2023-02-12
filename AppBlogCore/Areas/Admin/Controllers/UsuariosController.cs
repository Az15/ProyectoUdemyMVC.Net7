using BlogCore.AccesoDatos.Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace AppBlogCore.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UsuariosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;


        public UsuariosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;

        }

        [HttpGet]
        public IActionResult Index()
        {
            //Opcion 1. Obtener Usuarios.
            //return View(_contenedorTrabajo.Usuario.GetAll());
            //Opcion 2.
            var claimIdentity = (ClaimsIdentity)this.User.Identity;
            var usuarioActual = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return View(_contenedorTrabajo.Usuario.GetAll(u => u.Id != usuarioActual.Value));
        }

        [HttpGet]
        public IActionResult Bloquear(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _contenedorTrabajo.Usuario.BloquearUsuario(id);
            return RedirectToAction(nameof(Index));

        }
            [HttpGet]
          public IActionResult Desbloquear(string id)
          {
                if (id == null)
                {
                    return NotFound();
                }

                _contenedorTrabajo.Usuario.DesbloquearUsuario(id);
                return RedirectToAction(nameof(Index));
          }
        
    }
}