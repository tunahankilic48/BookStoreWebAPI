using FluentValidation;

namespace BookStore.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(c => c.GenreId).GreaterThan(0);
        }
    }
}
