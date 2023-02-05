using AppBlogCore.Data;
using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlogCore.AccesoDatos.Data.Repository
{
    internal class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {

        private readonly ApplicationDbContext _db;

        //Acceder y Obtener datos.
        public CategoriaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;   
        }


        public IEnumerable<SelectListItem> GetListaCategorias()
        {
            return _db.Categoria.Select(i => new SelectListItem()
                {
                    Text = i.Nombre,
                    Value = i.Id.ToString()
                }    
            ); 
        }

        public void Update(Categoria categoria)
        {
           var objDesdeDb = _db.Categoria.FirstOrDefault(s => s.Id == categoria.Id) ;
            objDesdeDb.Nombre = categoria.Nombre;
            objDesdeDb.Orden   = categoria.Orden;  

            _db.SaveChanges();
        }
    }
}
