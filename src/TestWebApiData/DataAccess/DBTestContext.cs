using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using TestWebApiData.Models;

namespace TestWebApiData.DataAccess
{
    public class DBTestContext : DbContext
    {
        public DBTestContext(DbContextOptions<DBTestContext> options)
             : base(options)
        {
        }
        public DbSet<Client> client { get; set; }

    }
}
