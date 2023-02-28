using AutoMapper;
using BookStore.DbOperations;

namespace BookStore.Application.GenreOperations.GetGenres
{
    public class GetGenresQuery
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public GetGenresQuery(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
