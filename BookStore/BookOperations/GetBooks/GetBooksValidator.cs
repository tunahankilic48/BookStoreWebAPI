using FluentValidation;

namespace BookStore.BookOperations.GetBooks
{
    public class GetBooksValidator : AbstractValidator<GetBooksQuery>
    {
        public GetBooksValidator()
        {
            RuleFor(c => c.BookId).GreaterThan(0);
        }
    }
}
