using FluentValidation;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorQueryDetailValidator : AbstractValidator<GetAuthorQueryDetail>
    {
        public GetAuthorQueryDetailValidator()
        {
            RuleFor(x=> x.AuthorId).GreaterThan(0);
        }
    }
}