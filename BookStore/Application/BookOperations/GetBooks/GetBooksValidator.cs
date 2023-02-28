using FluentValidation;

namespace BookStore.Application.BookOperations.GetBooks
{
    public class GetBooksValidator : AbstractValidator<GetBooksQuery>
    {
        public GetBooksValidator()
        {
            RuleFor(c => c.BookId).GreaterThan(0);
        }
    }
}
