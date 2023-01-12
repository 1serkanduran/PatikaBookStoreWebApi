using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;


namespace WebApi.Application.AuthorOprations.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorIdDto;
        private readonly BookStoreDBContext _context;

        public DeleteAuthorCommand(BookStoreDBContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.Include(x => x.Books).SingleOrDefault(x => x.Id == AuthorIdDto);
            if (author == null)
            {
                throw new InvalidOperationException("Silmek istediğiniz Id'e ait yazar yok");

            }

            if (_context.Books.Where(x => x.AuthorId == AuthorIdDto).Any())
            { 
                throw new InvalidOperationException("Silmek istediğiniz yazarın yayında kitabı var önce kitabı silmelisiniz");
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
          
        }

    }
}