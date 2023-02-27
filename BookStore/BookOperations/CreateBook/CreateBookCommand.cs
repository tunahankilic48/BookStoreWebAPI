using AutoMapper;
using BookStore.DbOperations;
using BookStore.Model;

namespace BookStore.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommand(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            Book? book = _context.Books.FirstOrDefault(x => x.Title == Model.Title);
            if (book is not null)
            {
                throw new InvalidOperationException("Kitap zaten mevcut");
            }

            book = _mapper.Map<Book>(Model);

            //book = new Book() { 
            //    Title = Model.Title,
            //    PageCount= Model.PageCount,
            //    PublishDate= DateTime.Now,
            //    GenreId= Model.GenreId
            //};
            _context.Books.Add(book);
            _context.SaveChanges();

        }
    }
}
