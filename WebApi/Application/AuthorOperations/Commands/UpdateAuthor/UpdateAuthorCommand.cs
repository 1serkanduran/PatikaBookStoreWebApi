using System;
using System.Linq;
using AutoMapper;
using WebApi.Application.AuthorOprations.CreateAuthor;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOprations.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public UpdateAuthorModel Model {get; set;}

        public UpdateAuthorCommand(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author =_context.Authors.SingleOrDefault(x=>x.Id== AuthorId);    
            if(author == null)
            {
                throw new InvalidOperationException("Bu ID'e sahip bir yazar yok");
            }
            if (_context.Authors.Any(x =>x.Name == Model.Name && x.Surname==Model.Surname))
            {
                throw new InvalidOperationException("Aynı isimli bir Yazar zaten mevcuttur.");
            }
            _mapper.Map<UpdateAuthorModel, Author>(Model, author);

            //author.Name= Model.Name != default ? Model.Name:author.Name;
            //author.SurName= Model.SurName != default ? Model.SurName : author.SurName;
            //author.BirthDate= Model.BirthDate != default ? Model.BirthDate : author.BirthDate;
            _context.SaveChanges();
        }
    }

   public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }  

        public DateTime DateOfBirth { get; set; }    

        public static implicit operator UpdateAuthorModel(CreateAuthorModel v)
        {
            throw new NotImplementedException();
        }
    }
}