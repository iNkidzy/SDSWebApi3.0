using System;
using Microsoft.EntityFrameworkCore;
using SDS.Core.Entity;


namespace SDS.Infrastructure.data
{
    public class sdsDBcontext: DbContext
    {
        public sdsDBcontext(DbContextOptions<sdsDBcontext> options)
            : base(options)
        {

        }

        public DbSet<Avatar> TodoItems { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
