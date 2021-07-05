using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using TestWorkForMonqlab.Domain.Data.Models;

namespace TestWorkForMonqlab.Domain.Data.DB.ModelsConfigurations
{
    public class MailConfiguration : IEntityTypeConfiguration<Mail>
    {
        /// <summary>
        /// Метод нужен для конфигурации модели <c>Mail</c> EF Core
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Mail> builder)
        {
            builder
                .ToTable("Mails")
                .HasKey(m => m.ID);

            builder.Property(m => m.ID)
                .ValueGeneratedOnAdd();

            builder.Property(m => m.Body)
                .HasMaxLength(int.MaxValue);

            builder.Property(m => m.FailedMessage)
                .HasMaxLength(int.MaxValue);

            builder.Property(m => m.Recipients)
                .HasMaxLength(int.MaxValue)
                .HasConversion(
                v => string.Join(',', v),
                v => new HashSet<string>(v.Split(',', StringSplitOptions.RemoveEmptyEntries)));
        }
    }
}
