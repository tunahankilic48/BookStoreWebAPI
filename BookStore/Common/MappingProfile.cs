using AutoMapper;
using BookStore.Application.AuthorOperations.CreateAuthor;
using BookStore.Application.AuthorOperations.GetAuthors;
using BookStore.Application.BookOperations.CreateBook;
using BookStore.Application.BookOperations.GetBooks;

using BookStore.Application.GenreOperations.CreateGenre;
using BookStore.Application.GenreOperations.GetGenres;
using BookStore.Application.UserOperations;
using BookStore.Model;

namespace BookStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name));

            CreateMap<Genre, GenresViewModel>();
            CreateMap<CreateGenreModel, Genre>();

            CreateMap<Author, AuthorsViewModel>();
            CreateMap<CreateAuthorModel, Author>();

            CreateMap<CreateUserModel,User>();

        }
    }
}
