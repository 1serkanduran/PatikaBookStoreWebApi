using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOprations.CreateAuthor
{
    public class CreateAuthorCommand
    {
        
        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;
        public CreateAuthorModel Model {get; set;}

    public CreateAuthorCommand(BookStoreDBContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        
    }


    public void Handle()
    {
        var author = _dbContext.Authors.SingleOrDefault(x => x.Name == Model.Name && x.Surname==Model.Surname);

        if(author != null)
        throw new InvalidOperationException("Yazar zaten mevcut");

        author = _mapper.Map<Author>(Model);
        
        _dbContext.Authors.Add(author);
        _dbContext.SaveChanges();
        
    }

    }

    public class CreateAuthorModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime PublisDate { get; set; }

    }

}