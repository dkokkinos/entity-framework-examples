using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static EntityFramework.ManyToManyWithJoinTable.Models;

namespace EntityFramework.ManyToManyWithJoinTable
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("users-db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}
