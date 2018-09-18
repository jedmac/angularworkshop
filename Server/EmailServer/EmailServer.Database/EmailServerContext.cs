using EmailServer.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmailServer.Database
{
    public class EmailServerContext : DbContext
    {
        public EmailServerContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Email> Emails { get; set; }
    }
}
