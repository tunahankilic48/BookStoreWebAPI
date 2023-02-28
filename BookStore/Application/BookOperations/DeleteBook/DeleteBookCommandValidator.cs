using FluentValidation;

namespace BookStore.Application.BookOperations.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(c => c.BookId).GreaterThan(0);
        }
    }
}
