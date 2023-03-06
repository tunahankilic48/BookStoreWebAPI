using AutoMapper;
using BookStore.Common;
using BookStore.DbOperations;
using BookStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly IBookStoreContext _context;
        private readonly IMapper _mapper;
        public int BookId { get; set; }

        public GetBooksQuery(IBookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            List<Book> bookList = _context.Books.Include(x => x.Genre).Include(x=>x.Author).OrderBy(x => x.Id).ToList();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
            //    new List<BooksViewModel>();
            //foreach (var book in bookList)
            //{
            //    vm.Add(new BooksViewModel()
            //    {
            //        Title = book.Title,
            //        Genre = ((GenreEnum)(book.GenreId)).ToString(),
            //        PageCount = book.PageCount,
            //        PublishDate = book.PublishDate.ToShortDateString(),
            //    });
            //}

            return vm;
        }

        public BooksViewModel Handle(int id)
        {
            Book book = _context.Books.Include(x=>x.Genre).FirstOrDefault(x => x.Id == id);
            if (book is null)
            {
                throw new InvalidOperationException("Belirtilen ID'ye sahip kitap bulunmamaktadır.");
            }
            BooksViewModel vm = _mapper.Map<BooksViewModel>(book);
            //    new BooksViewModel()
            //{
            //    Title = book.Title,
            //    Genre = ((GenreEnum)(book.GenreId)).ToString(),
            //    PageCount = book.PageCount,
            //    PublishDate = book.PublishDate.ToShortDateString(),

            //};
            return vm;
        }


    }
}
