using BookStore.DbOperations;
using BookStore.Model;

namespace BookStore.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly IBookStoreContext _context;
        public int GenreId { get; set; }

        public DeleteGenreCommand(IBookStoreContext context)
        {
            _context = context;
        }

        public void Handle(int id)
        {
            Genre? genre = _context.Genres.Find(id);
            if (genre is null)
            {
                throw new InvalidOperationException("Girilen ID'ye sahip kitap bulunmamaktadır");
            }
            _context.Genres.Remove(genre);
            _context.SaveChanges();

        }
    }
}
