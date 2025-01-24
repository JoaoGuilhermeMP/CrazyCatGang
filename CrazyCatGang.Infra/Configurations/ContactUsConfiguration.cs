using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyCatGang.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CrazyCatGang.Infra.Configurations
{
    public class ContactUsConfiguration : IEntityTypeConfiguration<Contacts>
    {
        public void Configure(EntityTypeBuilder<Contacts> builder)
        {
            builder.HasKey(c => c.Id); 

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd(); 

            builder.Property(c => c.FirstName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.LastName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.Email)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(c => c.ContactType)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.ContactReason)
                   .HasMaxLength(500);

            builder.HasOne(c => c.User)
                   .WithMany(u => u.Contacts)
                   .HasForeignKey(c => new { c.FirstName, c.LastName, c.Email })
                   .HasPrincipalKey(u => new { u.FirstName, u.LastName, u.Email })
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
