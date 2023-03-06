using BookStore.DbOperations;
using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.WebApiTest.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreContext context)
        {
            context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Noval"
                    });
        }
    }
}
