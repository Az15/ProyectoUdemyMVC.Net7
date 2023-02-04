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
    internal class ArticuloRepository : Repository<Articulo>, IArticuloRepository
    {

        private readonly ApplicationDbContext _db;

        //Acceder y Obtener datos.
        public ArticuloRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;   
        }

        public void Update(Articulo articulo)
        {
           var objDesdeDb = _db.Articulo.FirstOrDefault(s => s.Id == articulo.Id) ;
            objDesdeDb.Nombre = articulo.Nombre;
            objDesdeDb.Descripcion   = articulo.Descripcion;  
            objDesdeDb.UrlImagen= articulo.UrlImagen;
            objDesdeDb.CategoriaId = articulo.CategoriaId;
        }



    }
}
