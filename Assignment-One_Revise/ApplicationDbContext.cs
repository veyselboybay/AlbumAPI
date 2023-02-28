using Assignment_One_Revise.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_One_Revise
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Image> Images { get; set; }
        public DbSet<Album> Albums { get; set; }
    }
}
