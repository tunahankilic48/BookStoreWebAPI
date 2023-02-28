using FluentValidation;

namespace BookStore.Application.BookOperations.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(c => c.Model.PageCount).GreaterThan(0);
            RuleFor(c => c.Model.PublishDate).NotEmpty().LessThan(DateTime.Now);
            RuleFor(c => c.Model.Title).NotEmpty().MinimumLength(1);
        }
    }
}
