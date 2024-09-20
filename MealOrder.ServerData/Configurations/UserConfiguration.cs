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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateDate)
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            builder.Property(x => x.IsAktiv).IsRequired()
                .HasDefaultValueSql("1");

        }
    }
}
