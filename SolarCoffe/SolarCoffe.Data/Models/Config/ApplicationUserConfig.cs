using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarCoffe.Data.Models.Auth;

namespace SolarCoffe.Data.Models.Config
{
    public class ApplicationUserConfig
    {
        public ApplicationUserConfig(EntityTypeBuilder<ApplicationUser> entityTypeBuilder) 
        {
            entityTypeBuilder.HasMany(e => e.UserRoles)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .IsRequired();
        }
    }
}
