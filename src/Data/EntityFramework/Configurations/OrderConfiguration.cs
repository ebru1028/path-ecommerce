using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityFramework.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Status).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.ShippingCompany).WithMany(x => x.Orders).HasForeignKey(x=>x.ShippingCompanyId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}