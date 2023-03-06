using BookStore.Application.BookOperations.CreateBook;
using BookStore.DbOperations;
using BookStore.Model;

namespace BookStore.Application.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly IBookStoreContext _context;
        public int BookId { get; set; }

        public DeleteBookCommand(IBookStoreContext context)
        {
            _context = context;
        }

        public void Handle(int id)
        {
            Book? book = _context.Books.Find(id);
            if (book is null)
            {
                throw new InvalidOperationException("Girilen ID'ye sahip kitap bulunmamaktadır");
            }
            _context.Books.Remove(book);
            _context.SaveChanges();

        }
    }
}
