using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityFramework.Configurations
{
    public class AdminRoleMapConfiguration : IEntityTypeConfiguration<AdminRoleMap>
    {
        public void Configure(EntityTypeBuilder<AdminRoleMap> builder)
        {
            builder.HasKey(x => new { x.AdminId, x.RoleId });
            builder.HasOne(x => x.Admin).WithMany(x => x.RoleMaps).HasForeignKey(x=>x.AdminId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Role).WithMany(x => x.AdminMaps).HasForeignKey(x=>x.RoleId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}