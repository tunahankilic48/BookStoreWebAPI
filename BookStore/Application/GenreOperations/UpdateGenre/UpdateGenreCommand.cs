using BookStore.Application.BookOperations.UpdateBook;
using BookStore.DbOperations;
using BookStore.Model;

namespace BookStore.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public UpdateGenreModel Model { get; set; }
        public int GenreId { get; set; }

        private readonly BookStoreContext _context;

        public UpdateGenreCommand(BookStoreContext context)
        {
            _context = context;
        }

        public void Handle(int id)
        {
            Genre? genre = _context.Genres.Find(id);
            if (genre is null)
            {
                throw new InvalidOperationException("Girilen ID'ye sahip kategori bulunmamaktadır");
            }
            if(genre.Name == Model.Name && genre.Id != id)
            {
                throw new InvalidOperationException("Girilen kategori türü zaten mevcuttur.");
            }
            genre.Name = Model.Name != default ? Model.Name : genre.Name;
            genre.IsActive = Model.IsActive != default ? Model.IsActive : genre.IsActive;
            _context.SaveChanges();
        }
    }
}
