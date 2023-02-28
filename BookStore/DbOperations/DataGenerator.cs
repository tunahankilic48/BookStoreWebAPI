using BookStore.Model;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreContext>>()))
            {
                if (context.Books.Any() && context.Genres.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Noval"
                    });

                context.Authors.AddRange(
                    new Author
                    {
                        Name = "Eric Ries",
                        BirthDate = new DateTime(1978, 09, 22)
                    },
                    new Author
                    {
                        Name = "Charlotte Perkins Gilman",
                        BirthDate = new DateTime(1860, 07, 03)
                    },
                    new Author
                    {
                        Name = "Frank Herbert",
                        BirthDate = new DateTime(1920, 10, 08)
                    }
                    );

                context.Books.AddRange(
                    new Book
                    {
                        // Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1 /* Personal Growth */,
                        AuthorId = 1 ,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },

                    new Book
                    {
                        // Id = 2,
                        Title = "Herland",
                        GenreId = 2 /* Science Fiction*/,
                        AuthorId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 05, 23)
                    },

                    new Book
                    {
                        // Id = 3,
                        Title = "Dune",
                        GenreId = 2 /* Science Fiction*/,
                        AuthorId = 3,
                        PageCount = 540,
                        PublishDate = new DateTime(2001, 12, 21)
                    });

                context.SaveChanges();
            }
        }
    }
}
