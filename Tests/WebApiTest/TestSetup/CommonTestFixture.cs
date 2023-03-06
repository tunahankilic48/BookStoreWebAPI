using AutoMapper;
using BookStore.Common;
using BookStore.DbOperations;
using Microsoft.EntityFrameworkCore;


namespace Tests.WebApiTest.TestSetup
{
    public class CommonTestFixture
    {
        public BookStoreContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<BookStoreContext>().UseInMemoryDatabase(databaseName: "BookStoreTestDb").Options;
            Context = new BookStoreContext(options);
            Context.Database.EnsureCreated();
            Context.AddBooks();
            Context.AddGenres();
            Context.AddAuthors();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cnf => { cnf.AddProfile<MappingProfile>(); }).CreateMapper();

        }
    }
}
