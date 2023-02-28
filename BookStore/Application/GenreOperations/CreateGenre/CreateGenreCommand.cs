using AutoMapper;
using BookStore.DbOperations;
using BookStore.Model;

namespace BookStore.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public CreateGenreCommand(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            Genre? genre = _context.Genres.FirstOrDefault(x => x.Name == Model.Name);
            if (genre is not null)
            {
                throw new InvalidOperationException("Kategori zaten mevcut");
            }

            genre = _mapper.Map<Genre>(Model);

            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }
}
