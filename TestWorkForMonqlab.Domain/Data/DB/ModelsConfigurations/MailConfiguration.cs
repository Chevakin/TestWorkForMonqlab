using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWorkForMonqlab.Domain.Data.Models;

namespace TestWorkForMonqlab.Domain.Data.DB.ModelsConfigurations
{
    public class MailConfiguration : IEntityTypeConfiguration<Mail>
    {
        public void Configure(EntityTypeBuilder<Mail> builder)
        {
            builder
                .ToTable("Mails")
                .HasKey(m => m.ID);

            builder.Property(m => m.ID)
                .ValueGeneratedOnAdd();

            builder.Property(m => m.Body)
                .HasMaxLength(int.MaxValue);

            builder.Property(m => m.Recipients);
        }
    }
}
