using AutoMapper;
using BookStore.Application.BookOperations.CreateBook;
using BookStore.Application.BookOperations.GetBooks;

using BookStore.Application.GenreOperations.CreateGenre;
using BookStore.Application.GenreOperations.GetGenres;

using BookStore.Model;

namespace BookStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<Genre, GenresViewModel>();
            CreateMap<CreateGenreModel, Genre>();
        }
    }
}
