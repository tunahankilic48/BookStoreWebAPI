﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Model
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; } // Book Category
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }


    }
}
