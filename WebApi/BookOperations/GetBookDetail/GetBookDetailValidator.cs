using FluentValidation;
using WebApi.BookOperations.GetBookDetail;


namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailValidator : AbstractValidator<GetBookDetailQuery>
    {
        public  GetBookDetailValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}