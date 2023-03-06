using BookStore.DbOperations;
using BookStore.Model;

namespace BookStore.Application.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly IBookStoreContext _context;
        public int AuthorId { get; set; }

        public DeleteAuthorCommand(IBookStoreContext context)
        {
            _context = context;
        }

        public void Handle(int id)
        {
            Author? author = _context.Authors.Find(id);
            if (author is null)
            {
                throw new InvalidOperationException("Girilen ID'ye sahip yazar bulunmamaktadır");
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();

        }
    }
}
