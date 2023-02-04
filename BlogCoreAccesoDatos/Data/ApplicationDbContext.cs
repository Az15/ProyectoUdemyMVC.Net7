using BlogCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppBlogCore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Aca se agregan los modelos para una migracion exitosa.
        public DbSet<Categoria> Categoria { get; set; } 
       
        public DbSet<Articulo> Articulo { get; set; }
    }
}