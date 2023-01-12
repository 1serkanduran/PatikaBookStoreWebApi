using System;
using FluentValidation;
using WebApi.Application.AuthorOprations.UpdateAuthor;


namespace WebApi.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(1);
            RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(1);
            RuleFor(command => command.Model.DateOfBirth.Date).NotEmpty().LessThan(DateTime.Now.AddYears(-18));
        }
    }
}