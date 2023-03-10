using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId {get;set;}
        public GetBookDetailQuery(BookStoreDBContext dBContext, IMapper mapper)
        {
            _dbContext = dBContext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book=_dbContext.Books.Include(x=>x.Genre).Where(book=> book.Id==BookId).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException("Kitap bulunamad─▒");
            BookDetailViewModel vm=_mapper.Map<BookDetailViewModel>(book); 
            return vm;
        }
    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}