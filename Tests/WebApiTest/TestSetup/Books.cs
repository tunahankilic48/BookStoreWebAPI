using BookStore.DbOperations;
using BookStore.Model;

namespace Tests.WebApiTest.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreContext context)
        {
            context.Books.AddRange(
                    new Book
                    {
                        // Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1 /* Personal Growth */,
                        AuthorId = 1,
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
        }
    }
}
