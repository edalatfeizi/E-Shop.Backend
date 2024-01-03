using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Data.EntityTypeConfigurations
{
    public class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
           builder.ToTable("OrderItems", EShopDbContext.DB_SCHEMA);
           builder.HasKey(p => p.Id);

            builder.Property(p => p.UnitPrice)
                 .HasPrecision(18, 2);

            builder.HasOne(p => p.Order)
                .WithMany()
                .HasForeignKey(p => p.OrderId);
        }
    }
}
