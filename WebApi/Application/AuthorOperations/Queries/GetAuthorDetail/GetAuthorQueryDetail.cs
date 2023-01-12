using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorQueryDetail
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public GetAuthorQueryDetail(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
          var author= _context.Authors.SingleOrDefault(x=> x.Id==AuthorId);
            if (author == null)
            {
                throw new InvalidOperationException("Yazar bulunamadı");
            }
            AuthorDetailViewModel returnAuthor = _mapper.Map<AuthorDetailViewModel>(author);
            return returnAuthor;

        }

        public class AuthorDetailViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
          
            public DateTime BirthDate { get; set; }
        }
    }
}