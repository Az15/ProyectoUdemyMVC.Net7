using AppBlogCore.Data;
using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlogCore.AccesoDatos.Data.Repository
{
    internal class SliderRepository : Repository<Slider>, ISliderRepository
    {

        private readonly ApplicationDbContext _db;

        //Acceder y Obtener datos.
        public SliderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;   
        }


        public void Update(Slider slider)
        {
           var objDesdeDb = _db.Sliders.FirstOrDefault(s => s.Id == slider.Id) ;
            objDesdeDb.Nombre = slider.Nombre;
            objDesdeDb.Estado   = slider.Estado;  
            objDesdeDb.UrlImagen= slider.UrlImagen;

            _db.SaveChanges();
          
        }



    }
}
