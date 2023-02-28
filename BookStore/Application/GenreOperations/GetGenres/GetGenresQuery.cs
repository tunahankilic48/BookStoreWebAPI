using AutoMapper;
using BookStore.DbOperations;
using BookStore.Model;

namespace BookStore.Application.GenreOperations.GetGenres
{
    public class GetGenresQuery
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        public int GendreId { get; set; }

        public GetGenresQuery(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            List<Genre> genres = _context.Genres.Where(x=>x.IsActive).OrderBy(x=>x.Id).ToList();
            List<GenresViewModel> gl = _mapper.Map<List<GenresViewModel>>(genres);
            return gl;
        }

        public GenresViewModel Handle(int id)
        {
            Genre genre = _context.Genres.FirstOrDefault(x => x.IsActive && x.Id == id);
            if (genre is null)
            {
                throw new InvalidOperationException("Kategori bulunamadı.");
            }
            GenresViewModel gl = _mapper.Map<GenresViewModel>(genre);
            return gl;
        }
    }
}
