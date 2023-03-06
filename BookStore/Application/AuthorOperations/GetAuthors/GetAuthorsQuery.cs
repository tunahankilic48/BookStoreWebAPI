using AutoMapper;
using BookStore.Application.BookOperations.GetBooks;
using BookStore.DbOperations;
using BookStore.Model;

namespace BookStore.Application.AuthorOperations.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly IBookStoreContext _context;
        private readonly IMapper _mapper;
        public int AuthorId { get; set; }

        public GetAuthorsQuery(IBookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorsViewModel> Handle()
        {
            List<Author> author = _context.Authors.OrderBy(x => x.Id).ToList();
            List<AuthorsViewModel> vm = _mapper.Map<List<AuthorsViewModel>>(author);
            return vm;
        }

        public AuthorsViewModel Handle(int id)
        {
            Author author = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (author is null)
            {
                throw new InvalidOperationException("Belirtilen ID'ye sahip yazar bulunmamaktadır.");
            }
            AuthorsViewModel vm = _mapper.Map<AuthorsViewModel>(author);
            return vm;
        }
    }
}
