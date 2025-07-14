using DeMoMVC.Models;
using DeMoMVC.Models.Entities;
using Microsoft.EntityFrameworkCore;
using StudentModel = DeMoMVC.Models.Entities.Student;

namespace DeMoMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    
    public DbSet<DaiLy> DaiLys { get; set; } = null!;
    public DbSet<StudentModel> Students { get; set; } = null!;
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<DeMoMVC.Models.HeThongPhanPhoi> HeThongPhanPhoi { get; set; } = default!;
    }
}