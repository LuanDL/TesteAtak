using Microsoft.EntityFrameworkCore;
using TesteAtak.Models;

namespace TesteAtak.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
    }
}
