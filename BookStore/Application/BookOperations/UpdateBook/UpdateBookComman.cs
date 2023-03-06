using BookStore.Application.BookOperations.CreateBook;
using BookStore.DbOperations;
using BookStore.Model;

namespace BookStore.Application.BookOperations.UpdateBook
{
    public class UpdateBookComman
    {
        public UpdateBookModel Model { get; set; }
        public int BookId { get; set; }

        private readonly IBookStoreContext _context;

        public UpdateBookComman(IBookStoreContext context)
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
            book.Title = Model.Title != default ? Model.Title : book.Title;
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            _context.SaveChanges();
        }
    }
}
