using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class WebApiDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
          => options.UseSqlServer("Server=DESKTOP-LIMLNDB;Database=WebAPIDB;Trusted_connection=true;");

        //public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options) { }
        //push hatası deneme


        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AutPersonCredential> AutPersonCredentials { get; set; }
        public DbSet<Employee> Employees { get; set; }

        
    }
}
