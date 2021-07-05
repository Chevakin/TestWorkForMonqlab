using Microsoft.EntityFrameworkCore;
using TestWorkForMonqlab.Domain.Data.DB.ModelsConfigurations;
using TestWorkForMonqlab.Domain.Data.Models;

namespace TestWorkForMonqlab.Domain.Data.DB
{
    public class MonqlabDbContext :  DbContext
    {
        public DbSet<Mail> Mails { get; set; }

        public MonqlabDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MailConfiguration());
        }
    }
}
