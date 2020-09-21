using Chat.API.Models.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Chat.API
{
    public class ChatContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=chatappdb;Trusted_Connection=True;");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
