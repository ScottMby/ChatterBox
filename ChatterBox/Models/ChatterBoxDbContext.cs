using Microsoft.EntityFrameworkCore;
using System.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ChatterBox.Models
{
    public class ChatterBoxDbContext : DbContext
    {
        ConnectionString? connectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseMySQL(connectionString.value);
        }
    }
}
