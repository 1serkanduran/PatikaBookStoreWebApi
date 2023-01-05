using FluentValidation;
using WebApi.Application.GenreOperations.DeleteGenre;

namespace WebApi.Application.GenreOperations.CreateGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(command=> command.GenreId).GreaterThan(0);
        }
    }
}