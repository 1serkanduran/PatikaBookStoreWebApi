using FluentValidation;
using WebApi.Application.GenreOperations.UpdateGenre;

namespace WebApi.Application.GenreOperations.CreateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command=>command.Model.Name).NotEmpty().MinimumLength(4).When(x=>x.Model.Name !=string.Empty);
        }
    }
}