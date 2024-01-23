using ODD.Api.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ODD.Api.Infrastructure.Database.Context.SSMS.Configuration
{
    public class UserProfileEntityConfiguration : IEntityTypeConfiguration<UserProfileModel>
    {
        public void Configure(EntityTypeBuilder<UserProfileModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasOne(x => x.User)
                .WithOne(x => x.UserProfile)
                .HasForeignKey<UserProfileModel>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
