using Microsoft.EntityFrameworkCore;
using static EntityFramework.ManyToManyWithoutJoinTable.Models;

namespace EntityFramework.ManyToManyWithoutJoinTable
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await using var ctx = new AppContext();

            var jim = new User() { Name = "Jim" };
            var nick = new User() { Name = "Nick" };

            var designPatterns = new Book()
            {
                Name = "Design Patterns",
                Users = new List<User> { jim, nick }
            };
            Book refactoring = new Book()
            {
                Name = "Refactoring",
                Users = new List<User> { jim }
            };


            ctx.AddRange(jim, nick, designPatterns, refactoring);
            await ctx.SaveChangesAsync();


            var users = await ctx.Users.Where(u =>
               u.BooksRead.Any(b => b.Name == "Design Patterns")).ToListAsync();

            foreach (var user in users)
            {
                Console.WriteLine("User: " + user.Name);
            }
        }
    }
}