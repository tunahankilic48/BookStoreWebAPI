using AutoMapper;
using BookStore.Application.BookOperations.CreateBook;
using BookStore.DbOperations;
using BookStore.Model;

namespace BookStore.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
