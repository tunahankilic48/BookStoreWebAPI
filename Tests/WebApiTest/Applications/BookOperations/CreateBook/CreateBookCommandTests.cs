using AutoMapper;
using BookStore.Application.BookOperations.CreateBook;
using BookStore.DbOperations;
using BookStore.Model;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.WebApiTest.TestSetup;

namespace Tests.WebApiTest.Applications.BookOperations.CreateBook
{
    public class CreateBookCommandTests :IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture textFixture)
        {
            _context =textFixture.Context;
            _mapper = textFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationExceptionShouldBeReturn()
        {
            //Arrange(Hazırlık)
            
            var book = new Book()
            {
                Title = "WhenAlreadyExistBookTitleIsGiven_InvalidOperationExceptionShouldBeReturn",
                PageCount = 100,
                PublishDate= DateTime.Now.AddDays(-50),
                GenreId = 1,
                AuthorId = 1, 
            };

            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new CreateBookModel() { Title = book.Title };

            //Act(Çalıştırma) & Assert(Doğrulama)

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");
        }

        [Fact]
        public void WhenValidInputIsGiven_Book_ShouldBeCreated()
        {
            //Arrange(Hazırlık)
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);

            CreateBookModel model = new CreateBookModel()
            {
                Title = "WhenValidInputIsGiven_Book_ShouldBeCreated",
                PageCount = 100,
                PublishDate = DateTime.Now.AddMonths(-3),
                GenreId = 1,
            };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            //Act(Çalıştırma) & Assert(Doğrulama)

            var book = _context.Books.FirstOrDefault(book => book.Title == command.Model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
            book.GenreId.Should().Be(model.GenreId);
        }
    }
}
