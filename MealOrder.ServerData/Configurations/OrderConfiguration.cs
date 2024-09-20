using MealOrder.ServerData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealOrder.ServerData.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateDate)
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            builder.Property(x => x.IsAktiv).IsRequired()
                .HasDefaultValueSql("1");

            builder.Property(x=>x.Description).HasMaxLength(250);

            builder.HasOne(x=>x.User).WithMany(x=>x.Orders).HasForeignKey(x=>x.UserId);

            builder.HasOne(x => x.Supplier).WithMany(x => x.Orders).HasForeignKey(x => x.SupplierId);
            builder.HasMany(x => x.OrderItems).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);

        }
    }
}
