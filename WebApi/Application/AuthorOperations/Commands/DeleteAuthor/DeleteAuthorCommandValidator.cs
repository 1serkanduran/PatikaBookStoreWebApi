using FluentValidation;
using WebApi.Application.AuthorOprations.DeleteAuthor;


namespace WebApi.Application.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(x=> x.AuthorIdDto).GreaterThan(0);
        }
    }
}