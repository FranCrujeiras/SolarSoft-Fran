using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using SolarSoft_1._0.Models;

namespace SolarSoft_1._0.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Terreno> Terrenos { get; set; }
        public DbSet<Panel> Panel { get; set; }
    }
}
