using AppBlogCore.Data;
using BlogCore.Models;
using BlogCore.Utilidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Inicializador
{
    public class InicializadorDB : IinicializadorDB
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public InicializadorDB(ApplicationDbContext db, UserManager<ApplicationUser>  userManager , RoleManager<IdentityRole> roleManager)
        {
            _db= db;
            _userManager = userManager;
            _roleManager= roleManager;
        }


        public void Inicializar()
        {

            try
            {
                //Revisa que no queden pendientes a enviar migraciones.
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception) { }

            //No me queria dejar crear el role asi que lo tuve que comentar. Lo voy a descomentar para que haga el return y no me cree 50 veces el mismo usuario y roles jsjsjs.
            if (_db.Roles.Any(ro => ro.Name == CNT.Admin)) return;

            _roleManager.CreateAsync(new IdentityRole(CNT.Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(CNT.Usuario)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser{
                UserName = "admin1@gmail.com",
                Email = "admin1@gmail.com",
                EmailConfirmed= true,
                Nombre = "HolaMundo"},
                "Admin123!").GetAwaiter().GetResult();

            ApplicationUser usuario = _db.ApplicationUser
                .Where(us => us.Email == "admin1@gmail.com")
                .FirstOrDefault();

            _userManager.AddToRoleAsync(usuario, CNT.Admin).GetAwaiter().GetResult();

        }
    }
}
