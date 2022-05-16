using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityFramework.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Slug).IsRequired();
            builder.Property(x => x.IsCancellationRequiresConfirmation).IsRequired();
            
            builder.HasOne(x => x.ShippingCompany).WithMany(x => x.Categories).HasForeignKey(x=>x.ShippingCompanyId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}