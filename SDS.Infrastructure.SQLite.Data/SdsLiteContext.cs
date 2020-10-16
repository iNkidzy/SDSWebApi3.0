using System;
using Microsoft.EntityFrameworkCore;
using SDS.Core.Entity;

namespace SDS.Infrastructure.SQLite.Data
{
    public class SdsLiteContext: DbContext
    {
        public SdsLiteContext(DbContextOptions<SdsLiteContext> opt) : base(opt)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avatar>().HasKey(c => new { c.Price });
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<AvatarType> AvatarTypes { get; set; }
        public DbSet<Avatar> Avatars { get; set; }

        
    }
}
