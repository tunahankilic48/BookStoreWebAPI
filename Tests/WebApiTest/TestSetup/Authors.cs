using BookStore.DbOperations;
using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.WebApiTest.TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreContext context)
        {
            context.Authors.AddRange(
                    new Author
                    {
                        Name = "Eric Ries",
                        BirthDate = new DateTime(1978, 09, 22)
                    },
                    new Author
                    {
                        Name = "Charlotte Perkins Gilman",
                        BirthDate = new DateTime(1860, 07, 03)
                    },
                    new Author
                    {
                        Name = "Frank Herbert",
                        BirthDate = new DateTime(1920, 10, 08)
                    }
                    );
        }
    }
}
