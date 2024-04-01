using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.ManyToManyWithConfigurableJoinTable
{
    public class Models
    {
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ICollection<Book> BooksRead { get; set; }
        }

        public class Book
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ICollection<User> Users { get; set; }
        }

        public class UserBook
        {
            public int Id { get; set; }
            public User User { get; set; }
            public Book Book { get; set; }
            public DateTime ReadOn { get; set; }
        }
    }
}
