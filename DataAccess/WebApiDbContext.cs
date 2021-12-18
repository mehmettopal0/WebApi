using Entities;
using Entities.Buses;
using Entities.Cities;
using Entities.Customers;
using Entities.Expeditions;
using Entities.Reservation;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class WebApiDbContext:DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //  => options.UseSqlServer("Server=DESKTOP-LIMLNDB;Database=APIDatabase;Trusted_connection=true;");
        public WebApiDbContext()
        {

        }
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options) { }
        //push hatası deneme
        

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AutPersonCredential> AutPersonCredentials { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Expedition> Expeditions { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<City> Cities { get; set; }

    }
}
