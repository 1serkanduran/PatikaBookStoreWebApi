using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.BookOperations.CreateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Lord Of The Rings",0,0)]
        [InlineData("Lord Of The Rings",0,1)]
        [InlineData("Lord Of The Rings",100,0)]
        [InlineData("",0,0)]
        [InlineData("",100,0)]
        [InlineData("",0,1)]
        [InlineData("Lor",100,1)]
        [InlineData("Lord",100,0)]
        [InlineData("Lord",0,1)]
        [InlineData(" ",100,1)]           
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title,int pageCount,int genreId)
        {
            //arrange
            CreateBookCommand command=new CreateBookCommand(null,null);
            command.Model=new CreateBookModel(){
            Title=title,
            PageCount=pageCount,
            PublisDate = DateTime.Now.Date.AddYears(-1),
            GenreId=genreId
            };
            //act
            CreateBookCommandValidator validator=new CreateBookCommandValidator();
            var result= validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldBeReturnError()
        {
            CreateBookCommand command=new CreateBookCommand(null,null);
            command.Model=new CreateBookModel()
            {
            Title="Lord Of The Rings",
            PageCount=100,
            PublisDate = DateTime.Now.Date.AddYears(-2),
            GenreId=1
            };
            CreateBookCommandValidator validator=new CreateBookCommandValidator();
            var result= validator.Validate(command);

            result.Errors.Count.Should().Equals(0);
        }
    }
}   