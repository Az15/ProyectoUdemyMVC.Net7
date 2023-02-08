using AppBlogCore.Data;
using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlogCore.AccesoDatos.Data.Repository
{
    internal class UsuarioRepository : Repository<ApplicationUser>, IusuarioRepository
    {

        private readonly ApplicationDbContext _db;

        //Acceder y Obtener datos.
        public UsuarioRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;   
        }

        public void BloquearUsuario(string IdUsuario)
        {
            var usuarioDesdeDB = _db.ApplicationUser.FirstOrDefault(u => u.Id == IdUsuario);
            usuarioDesdeDB.LockoutEnd = DateTime.Now.AddYears(200);
            _db.SaveChanges();
        }

        public void DesbloquearUsuario(string ID)
        {
            var usuarioDesdeDB = _db.ApplicationUser.FirstOrDefault(u => u.Id == ID);
            usuarioDesdeDB.LockoutEnd = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
