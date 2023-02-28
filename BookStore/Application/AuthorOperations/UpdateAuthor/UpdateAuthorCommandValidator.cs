using FluentValidation;

namespace BookStore.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(c => c.AuthorId).GreaterThan(0);
            RuleFor(c => c.Model.BirthDate).NotEmpty().LessThan(DateTime.Now);
            RuleFor(c => c.Model.Name).NotEmpty().MinimumLength(1);
        }

    }
}
