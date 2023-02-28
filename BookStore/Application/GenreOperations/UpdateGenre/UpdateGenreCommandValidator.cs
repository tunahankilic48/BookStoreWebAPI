using BookStore.Application.BookOperations.UpdateBook;
using FluentValidation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BookStore.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(c => c.Model.Name).MinimumLength(1).When(x => x.Model.Name != string.Empty);
        }
    }
}
