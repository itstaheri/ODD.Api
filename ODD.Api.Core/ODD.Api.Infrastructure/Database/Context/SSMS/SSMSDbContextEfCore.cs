using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ODD.Api.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODD.Api.Domain.Entities.User;
using ODD.Api.Infrastructure.Database.Context.SSMS.Configuration;

namespace ODD.Api.Infrastructure.Database.Context.SSMS
{
    public class SSMSDbContextEfCore : DbContext, IApplicationSSMSEfCoreContext
    {
        public SSMSDbContextEfCore(DbContextOptions<SSMSDbContextEfCore> dbContext) : base(dbContext) { }

        public DbSet<UserModel> Tbl_User { get; set; }
        public DbSet<UserProfileModel> Tbl_UserProfile { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
