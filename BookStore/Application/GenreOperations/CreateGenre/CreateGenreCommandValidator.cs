using FluentValidation;

namespace BookStore.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(c => c.Model.Name).NotEmpty().MinimumLength(1);
        }
    }
}
