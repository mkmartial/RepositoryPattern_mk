using Microsoft.EntityFrameworkCore;
using RepositoryPattern_mk.Models;

namespace RepositoryPattern_mk.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
    }
}
