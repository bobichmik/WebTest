using Microsoft.EntityFrameworkCore;
using WebService.Models;

namespace WebService.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<DataModel> DataItems { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}