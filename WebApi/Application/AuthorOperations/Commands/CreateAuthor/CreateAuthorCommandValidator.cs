using FluentValidation;
using WebApi.Application.AuthorOprations.CreateAuthor;

namespace WebApi.Application.AuthorOperations.CreateAuthor
{

    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {

      public CreateAuthorCommandValidator()
      {

        RuleFor(x => x.Model.Name).MinimumLength(2).NotEmpty();
        RuleFor(x => x.Model.Surname).MinimumLength(2).NotEmpty();
        RuleFor(x => x.Model.BookId).NotEmpty().GreaterThan(0);
        
      }
      
    }
}