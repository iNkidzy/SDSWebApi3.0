using System;
using Microsoft.EntityFrameworkCore;
using SDS.Core.Entity;
using WebAPI.Models;

namespace WebAPI.data
{
    public class sdsDBcontext: DbContext
    {
        public sdsDBcontext(DbContextOptions<sdsDBcontext> options)
            : base(options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
