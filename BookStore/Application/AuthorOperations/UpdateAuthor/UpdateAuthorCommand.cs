using BookStore.Application.BookOperations.UpdateBook;
using BookStore.DbOperations;
using BookStore.Model;

namespace BookStore.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public UpdateAuthorModel Model { get; set; }
        public int AuthorId { get; set; }

        private readonly IBookStoreContext _context;

        public UpdateAuthorCommand(IBookStoreContext context)
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
            author.Name = Model.Name != default ? Model.Name : author.Name;
            author.BirthDate = Model.BirthDate != default ? Model.BirthDate : author.BirthDate;
            _context.SaveChanges();
        }
    }
}
