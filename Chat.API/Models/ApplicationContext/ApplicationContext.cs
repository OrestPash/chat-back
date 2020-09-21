using Microsoft.EntityFrameworkCore;
using MessageEntity = Entities.Message.Message;

namespace Chat.API.Models.ApplicationContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<MessageEntity> Messages { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
