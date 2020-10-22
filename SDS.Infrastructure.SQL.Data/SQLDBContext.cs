using System;
using Microsoft.EntityFrameworkCore;
using SDS.Core.Entity;

namespace SDS.Infrastructure.SQL.Data
{
    public class SQLDBContext: DbContext
    {
        public SQLDBContext(DbContextOptions<SQLDBContext> opt) : base(opt)
        {
        }

            public DbSet<Owner> Owners { get; set; }
            public DbSet<Avatar> Avatars { get; set; }
            public DbSet<AvatarType> AvatarTypes { get; set; }
            
    }
} 
    

