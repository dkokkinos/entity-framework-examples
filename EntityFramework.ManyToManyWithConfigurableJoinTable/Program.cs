using Microsoft.EntityFrameworkCore;
using static EntityFramework.ManyToManyWithConfigurableJoinTable.Models;

namespace EntityFramework.ManyToManyWithConfigurableJoinTable
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

            var userBook1 = new UserBook()
            {
                User = jim,
                Book = designPatterns,
                ReadOn = new DateTime(2020, 1, 1)
            };
            var userBook2 = new UserBook()
            {
                User = jim,
                Book = refactoring,
                ReadOn = new DateTime(2010, 1, 1)
            };
            var userBook3 = new UserBook()
            {
                User = nick,
                Book = refactoring,
                ReadOn = new DateTime(2020, 2, 1)
            };

            ctx.AddRange(jim, nick, designPatterns,
               refactoring, userBook1, userBook2, userBook3);
            await ctx.SaveChangesAsync();


            var readers = await ctx.UserBook.Where(u =>
               u.ReadOn > new DateTime(2010, 5, 5)).Select(x => x.User).ToListAsync();

            foreach (var user in readers)
            {
                Console.WriteLine("Reader: " + user.Name);
            }

            var users = await ctx.Users.Where(u =>
               u.BooksRead.Any(b => b.Name == "Design Patterns")).ToListAsync();

            foreach (var user in users)
            {
                Console.WriteLine("User: " + user.Name);
            }
        }
    }
}