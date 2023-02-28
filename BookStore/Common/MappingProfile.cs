﻿using AutoMapper;
using BookStore.Application.BookOperations.CreateBook;
using BookStore.Application.BookOperations.GetBooks;
using BookStore.Model;

namespace BookStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));


        }
    }
}
