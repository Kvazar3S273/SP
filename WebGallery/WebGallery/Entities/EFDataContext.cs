using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGallery.Entities.Data;
using WebGallery.Entities.Identity;

namespace WebGallery.Entities
{
    public class EFDataContext : IdentityDbContext<AppUser, AppRole, long, IdentityUserClaim<long>,
                                                   AppUserRole, IdentityUserLogin<long>,
                                                   IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public EFContext()
        {
        }
        public EFDataContext(DbContextOptions<EFDataContext> options)
            :base(options)
        {
                
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(@"Server=91.238.103.51;Port=5743;Database=ba2hdb;User Id=ba2h;Password=$544$B77w**G)K$t!ba2h22}");
            }
        }
        public DbSet<Car> Cars { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}
