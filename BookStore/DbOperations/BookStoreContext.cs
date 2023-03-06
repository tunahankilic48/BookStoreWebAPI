using BookStore.Model;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DbOperations
{
    public class BookStoreContext : DbContext, IBookStoreContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
