using AutoMapper;
using WebApi.Application.AuthorOprations;
using WebApi.Application.AuthorOprations.CreateAuthor;
using WebApi.Application.AuthorOprations.UpdateAuthor;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.Entities;
using static WebApi.Application.AuthorOperations.Queries.GetAuthorDetail.GetAuthorQueryDetail;
using static WebApi.Application.AuthorOperations.Queries.GetAuthors.GetAuthorQuery;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<Author, AuthorsViewModel>().ForMember(
                    dest => dest.DateOfBirth,
                    opt => opt.MapFrom(src => src.DateOfBirth.Date.ToString("dd/MM/yyyy"))
                );
            CreateMap<Author, AuthorDetailViewModel>().ForMember(
                    dest => dest.BirthDate,
                    opt => opt.MapFrom(src => src.DateOfBirth.Date.ToString("dd/MM/yyyy"))
                );
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<UpdateAuthorModel, Author>();
        }
    }
}