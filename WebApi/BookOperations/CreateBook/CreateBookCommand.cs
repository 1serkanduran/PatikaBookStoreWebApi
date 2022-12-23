using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model {get;set;} 
        private readonly BookStoreDBContext _dbContext;
        public CreateBookCommand(BookStoreDBContext dBContext)
        {
            _dbContext =dBContext;
        }

        public void Handle()
        {
            var book=_dbContext.Books.SingleOrDefault(x=> x.Title == Model.Title);
            if (book is not null)

                throw new InvalidOperationException("Kitap zaten mevcut");
                book=new();
                book.Title=Model.Title;
                book.PublishDate=Model.PublisDate;
                book.PageCount=Model.PageCount;
                book.GenreId=Model.GenreId;

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublisDate { get; set; }
        }
    }
}