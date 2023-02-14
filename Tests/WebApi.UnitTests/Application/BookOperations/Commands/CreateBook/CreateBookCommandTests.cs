using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.BookOperations.CreateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
            _mapper=testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //Arrage (Hazırlama)
            var book=new Book(){Title="Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn", PageCount=100, PublishDate=new System.DateTime(1990,01,05),GenreId=1};
            _context.Books.Add(book);
            _context.SaveChanges(); 
            CreateBookCommand command=new CreateBookCommand(_context,_mapper);
            command.Model=new CreateBookModel() {Title =book.Title};
            
            //Act - Assert (Çalıştırma - Doğrulama)
            FluentActions
                    .Invoking(()=>command.Handle())
                    .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");
        }
    }
}