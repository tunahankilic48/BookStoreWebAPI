using FluentValidation;

namespace BookStore.Application.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(c => c.AuthorId).GreaterThan(0);
        }
    }
}
