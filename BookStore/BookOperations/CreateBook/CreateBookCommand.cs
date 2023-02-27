using BookStore.DbOperations;
using BookStore.Model;

namespace BookStore.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreContext _context;

        public CreateBookCommand(BookStoreContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            Book? book = _context.Books.FirstOrDefault(x => x.Title == Model.Title);
            if (book is not null)
            {
                throw new InvalidOperationException("Kitap zaten mevcut");
            }
            book = new Book() { 
                Title = Model.Title,
                PageCount= Model.PageCount,
                PublishDate= DateTime.Now,
                GenreId= Model.GenreId
            };
            _context.Books.Add(book);
            _context.SaveChanges();

        }
    }
}
