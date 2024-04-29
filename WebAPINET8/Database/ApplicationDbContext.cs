using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace WebAPINET8.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Models.Customer> Customers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            try
            {
               var dbCreaator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (dbCreaator != null)
                {
                    if (!dbCreaator.CanConnect())
                        dbCreaator.Create();
                    if(!dbCreaator.HasTables())
                        dbCreaator.CreateTables();

                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        
    }
}
