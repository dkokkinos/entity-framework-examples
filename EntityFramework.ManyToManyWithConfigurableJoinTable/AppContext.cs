using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static EntityFramework.ManyToManyWithConfigurableJoinTable.Models;

namespace EntityFramework.ManyToManyWithConfigurableJoinTable
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UserBook> UserBook { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasMany(u => u.BooksRead)
               .WithMany(b => b.Users)
               .UsingEntity<UserBook>(
                  l => l.HasOne(ub => ub.Book).WithMany().HasForeignKey("BookId").HasPrincipalKey(nameof(Book.Id)),
                  r => r.HasOne(ub => ub.User).WithMany().HasForeignKey("UserId").HasPrincipalKey(nameof(User.Id)),
                  j => j.HasKey("BookId", "UserId"));
        }
    }
}
