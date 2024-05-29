using Microsoft.EntityFrameworkCore;

namespace BlazorServerCRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {
            
        }

        public DbSet<Product> products { get; set; } = default;
    }
}
