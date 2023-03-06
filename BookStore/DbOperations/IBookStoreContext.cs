using BookStore.Model;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DbOperations
{
    public interface IBookStoreContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<User> Users { get; set; }

        int SaveChanges();
    }   
}
