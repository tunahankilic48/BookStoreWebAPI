using FluentValidation;

namespace BookStore.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookComman>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(c => c.BookId).GreaterThan(0);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(c => c.Model.PageCount).GreaterThan(0);
            RuleFor(c => c.Model.PublishDate).NotEmpty().LessThan(DateTime.Now);
            RuleFor(c => c.Model.Title).NotEmpty().MinimumLength(1);
        }

    }
}
