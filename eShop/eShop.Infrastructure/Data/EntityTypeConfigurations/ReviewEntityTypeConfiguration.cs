using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Data.EntityTypeConfigurations
{
    public class ReviewEntityTypeConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
           builder.ToTable("Reviews", EShopDbContext.DB_SCHEMA);
           builder.HasKey(p => p.Id);

          
           builder.HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId);
        }
    }
}
