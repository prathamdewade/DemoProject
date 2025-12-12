using CodeFirstAproch.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstAproch.Data
{


    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> op) : base(op)
        {
            
        }
         public DbSet<Employee> Employees { get; set; }
    }
}
