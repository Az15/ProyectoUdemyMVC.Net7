using AppBlogCore.Data;
using BlogCore.AccesoDatos.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AppBlogCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticulosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly ApplicationDbContext _context;

        public ArticulosController(IContenedorTrabajo contenedorTrabajo, ApplicationDbContext context)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }








        #region Llamadas a la API

        [HttpGet]
        public ActionResult Getall()
        {
            //Opcion 1
            return Json(new { data = _contenedorTrabajo.Articulo.GetAll() });


        }
        /*
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Categoria.Get(id);
            if (objFromDb == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Error al intentar borrar la categoria."
                });
            }
            _contenedorTrabajo.Categoria.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new
            {
                success = true,
                message = "Categoria borrada correctamente"
            });
        }
        */
        #endregion
    }
}
