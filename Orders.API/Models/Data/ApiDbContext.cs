using Microsoft.EntityFrameworkCore;

namespace OrdersInfo.API.Models.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
    }
}
