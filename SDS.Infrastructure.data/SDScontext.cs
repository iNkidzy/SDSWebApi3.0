using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SDS.Core.Entity;

namespace SDS.Infrastructure.data
{
    public class SDScontext: DbContext

    {
        public SDScontext(DbContextOptions<SDScontext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AvatarType>()
            //   .HasKey(at => new { at.Id });
               


            //modelBuilder.Entity<Owner>()
            //    .HasKey(owner => new { owner.Id });

          

            modelBuilder.Entity<Avatar>()
             .HasOne(p => p.Owner)
             .WithMany(po => po.AvatarsOwned)
             .OnDelete(DeleteBehavior.SetNull);


        }

        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<AvatarType> AvatarTypes { get; set; }
    }
}
