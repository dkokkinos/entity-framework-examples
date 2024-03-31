using Microsoft.EntityFrameworkCore;
using static EntityFramework.ManyToManyWithJoinTable.Models;

namespace EntityFramework.ManyToManyWithJoinTable
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await using var ctx = new AppContext();
            var jim = new User() { Name = "Jim" };
            var nick = new User() { Name = "Nick" };

            var designPatterns = new Book() { Name = "Design Patterns" };
            var refactoring = new Book() { Name = "refactoring" };

            var userBook1 = new UserBook() { User = jim, Book = designPatterns };
            var userBook2 = new UserBook() { User = jim, Book = refactoring };
            var userBook3 = new UserBook() { User = nick, Book = refactoring };

            ctx.AddRange(jim, nick, designPatterns, refactoring, userBook1, userBook2, userBook3);
            await ctx.SaveChangesAsync();


            var users = await ctx.Users.Where(u => u.BooksRead.Any(us => us.Book.Name == "Design Patterns")).ToListAsync();
            foreach (var user in users)
            {
                Console.WriteLine("User: " + user.Name);
            }
        }

    }
}