using AutoMapper;
using BookStore.DbOperations;
using BookStore.Model;
using System.Globalization;

namespace BookStore.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly IBookStoreContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorCommand(IBookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            Author? author = _context.Authors.FirstOrDefault(x => x.Name == Model.Name);
            if (author is not null)
            {
                throw new InvalidOperationException("Yazar zaten mevcut");
            }

            author = _mapper.Map<Author>(Model);
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

    }
}
