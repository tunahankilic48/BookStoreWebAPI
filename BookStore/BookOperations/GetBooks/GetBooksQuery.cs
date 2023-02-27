using BookStore.Common;
using BookStore.DbOperations;
using BookStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreContext _context;

        public GetBooksQuery(BookStoreContext context)
        {
            _context = context;
        }

        public List<BooksViewModel> Handle()
        {
            List<Book> bookList = _context.Books.OrderBy(x => x.Id).ToList();
            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                vm.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    Genre = ((GenreEnum)(book.GenreId)).ToString(),
                    PageCount = book.PageCount,
                    PublishDate= book.PublishDate.ToShortDateString(),
                });
            }

            return vm;
        }

        
    }
}
