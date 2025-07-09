using DeMoMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DeMoMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Person> Person { get; set; } = null!;
    }
}