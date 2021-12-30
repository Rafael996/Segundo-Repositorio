using api.Models.Tipos;
using Microsoft.EntityFrameworkCore;

namespace api.Connection
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)   
        { 

        }
        public DbSet<Pessoa> pessoas { get; set; }
    }
}
