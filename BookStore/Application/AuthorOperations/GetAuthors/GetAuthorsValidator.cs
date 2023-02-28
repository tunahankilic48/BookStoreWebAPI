using FluentValidation;

namespace BookStore.Application.AuthorOperations.GetAuthors
{
    public class GetAuthorsValidator : AbstractValidator<GetAuthorsQuery>
    {
        public GetAuthorsValidator()
        {
            RuleFor(x=>x.AuthorId).GreaterThan(0);
        }
    }
}
