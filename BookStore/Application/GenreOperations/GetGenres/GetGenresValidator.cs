using FluentValidation;

namespace BookStore.Application.GenreOperations.GetGenres
{
    public class GetGenresValidator : AbstractValidator<GetGenresQuery>
    {
        public GetGenresValidator()
        {
            RuleFor(c => c.GendreId).GreaterThan(0);
        }
    }
}
