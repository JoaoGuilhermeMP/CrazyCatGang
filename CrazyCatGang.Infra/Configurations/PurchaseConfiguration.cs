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
   
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                    .ValueGeneratedOnAdd();

            builder.Property(p => p.PurchaseNumber)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(p => p.ItemType)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(p => p.ItemName)
                    .HasMaxLength(200)
                    .IsRequired();

            builder.Property(p => p.ItemDescription)
                    .HasMaxLength(500);

            builder.Property(p => p.ItemPrice)
                    .HasColumnType("decimal(18,2)");

            builder.Property(p => p.BuyerCPF)
                    .HasMaxLength(14)
                    .IsRequired();

            builder.HasOne(p => p.User)
                    .WithMany(u => u.Purchases)
                    .HasForeignKey(p => p.BuyerCPF)
                    .HasPrincipalKey(u => u.CPF)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }

    
}
