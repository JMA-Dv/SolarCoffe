using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarCoffe.Data.Models.Auth;

namespace SolarCoffe.Data.Models.Config
{
    public class ApplicationRoleConfig
    {
        public ApplicationRoleConfig(EntityTypeBuilder<ApplicationRole> entityTypeBuilder) 
        {
            entityTypeBuilder.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(e => e.RoleId)
                .IsRequired();
        }
    }
}
