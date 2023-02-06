using AppBlogCore.Models;
using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Models;
using BlogCore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppBlogCore.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;
     
        public HomeController(IContenedorTrabajo contenedorTrabajo)
        {
           _contenedorTrabajo = contenedorTrabajo;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Slider = _contenedorTrabajo.Slider.GetAll(),
                ListaDeArticulos = _contenedorTrabajo.Articulo.GetAll()
            };

            //Esto es porque si no se crashea todo por culpa del slider.
            ViewBag.IsHome = true;

            return View(homeVM);
        }

        public IActionResult Details(int Id)
        {
            var articuloDesdeDb = _contenedorTrabajo.Articulo.Get(Id);
            return View(articuloDesdeDb);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}