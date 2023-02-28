using BookStore.Application.BookOperations.CreateBook;
using FluentValidation;

namespace BookStore.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommandValidation : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidation()
        {
            RuleFor(c => c.Model.BirthDate).NotEmpty().LessThan(DateTime.Now);
            RuleFor(c => c.Model.Name).NotEmpty().MinimumLength(1);
        }
    }
}
