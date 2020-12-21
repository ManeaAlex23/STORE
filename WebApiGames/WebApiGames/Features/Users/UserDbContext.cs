

namespace WebApiGames.Features
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using System.Threading.Tasks;
    using System;
    using WebApiGames.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Linq;
    using WebApiGames.Data.Models.Base;
    using WebApiGames.Infrastructure.Services;

    public class UserDbContext : IdentityDbContext<User>
    {
        public readonly ICurrentUserService currentUser;
        public UserDbContext(DbContextOptions<UserDbContext> options,
            ICurrentUserService currentUser)
            : base(options)
        {
            this.currentUser = currentUser;
        }

        public DbSet<GamesReq> Games { get; set; }


        public override int SaveChanges()
        {
            this.ApplyAuditInfo();
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfo();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfo();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<GamesReq>()
                .HasOne(g => g.User)
                .WithMany(u => u.Games)
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Restrict);



            base.OnModelCreating(builder);
        }
        private void ApplyAuditInfo()
        {
            this.ChangeTracker
                .Entries()
                .Select(entry => new
                {
                    entry.Entity,
                    entry.State
                })
                .ToList()
                .ForEach(entry =>
                {
                    var userName = this.currentUser.GetUserName();

                    if (entry.Entity is IDeletableEntity deletable)
                    {
                        if(entry.State == EntityState.Deleted)
                        {
                            deletable.DeletedOn = DateTime.UtcNow;
                            deletable.DeletedBy = userName;

                        }
                                                                     
                    }
                    if(entry.Entity is IEntity entity)
                    {
                        if(entry.State == EntityState.Added)
                        {
                            entity.CreatedOn = DateTime.UtcNow;
                            entity.CreatedBy = userName;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            entity.ModefiedOn = DateTime.UtcNow;
                            entity.ModifiedBy = userName;
                        }
                    }
               
                    
                }); 
              
        }

        internal Task FindAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
