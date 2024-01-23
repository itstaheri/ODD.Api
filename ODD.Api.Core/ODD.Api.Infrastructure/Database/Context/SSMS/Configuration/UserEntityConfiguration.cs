using ODD.Api.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Infrastructure.Database.Context.SSMS.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.Id);

            //configure value objects
            builder.OwnsOne(x => x.Email).Property(x => x.Value);
            builder.OwnsOne(x => x.Id).Property(x => x.Value);

            builder.HasKey(x => x.Id);
            builder
                .HasOne(x=>x.UserProfile)
                .WithOne(x=>x.User)
                .HasForeignKey<UserProfileModel>(x=>x.UserId);
        }
    }
}
