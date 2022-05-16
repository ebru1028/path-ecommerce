using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityFramework.Configurations
{
    public class OrderProductMapConfiguration : IEntityTypeConfiguration<OrderProductMap>
    {
        public void Configure(EntityTypeBuilder<OrderProductMap> builder)
        {
            builder.HasKey(x => new { x.OrderId, x.ProductId });
            builder.HasOne(x => x.Order).WithMany(x => x.ProductMaps).HasForeignKey(x=>x.OrderId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Product).WithMany(x => x.OrderMaps).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}