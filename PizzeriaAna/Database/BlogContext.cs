using Microsoft.EntityFrameworkCore;
using PizzeriaAna.Models;

namespace PizzeriaAna.Database
{
    public class BlogContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=BlogDB1s;" +
            "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
