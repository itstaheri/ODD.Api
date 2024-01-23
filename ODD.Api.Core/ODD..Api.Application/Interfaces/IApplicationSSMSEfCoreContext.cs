using Microsoft.EntityFrameworkCore;
using ODD.Api.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Application.Interfaces
{
    public interface IApplicationSSMSEfCoreContext
    {
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        public DbSet<UserModel> Tbl_User { get; set; }
        public DbSet<UserProfileModel> Tbl_UserProfile { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
