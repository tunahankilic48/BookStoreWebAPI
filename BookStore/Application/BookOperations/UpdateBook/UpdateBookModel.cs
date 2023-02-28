namespace BookStore.Application.BookOperations.UpdateBook
{
    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
