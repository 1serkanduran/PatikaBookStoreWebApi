using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.CreateAuthor;
using WebApi.Application.AuthorOperations.DeleteAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.AuthorOperations.UpdateAuthor;
using WebApi.Application.AuthorOprations.CreateAuthor;
using WebApi.Application.AuthorOprations.DeleteAuthor;
using WebApi.Application.AuthorOprations.UpdateAuthor;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorQuery query=new GetAuthorQuery(_context,_mapper);
            var obj=query.Handle();
            return Ok(obj);
        }
        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            GetAuthorQueryDetail query = new GetAuthorQueryDetail(_context,_mapper);
            query.AuthorId = id;
            GetAuthorQueryDetailValidator validations = new GetAuthorQueryDetailValidator();
            validations.ValidateAndThrow(query);
            var obj = query.Handle();
            return Ok(obj);
        }
        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command= new CreateAuthorCommand(_context,_mapper);
            command.Model= newAuthor;

            CreateAuthorCommandValidator validations = new CreateAuthorCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok(command);
        }
        [HttpPut("id")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updateAuthor)
        {
            UpdateAuthorCommand command= new UpdateAuthorCommand(_context, _mapper);
            command.AuthorId = id;
            command.Model = updateAuthor;

            UpdateAuthorCommandValidator validationRules = new UpdateAuthorCommandValidator();
            validationRules.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpDelete("id")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorIdDto =id;
            DeleteAuthorCommandValidator validations = new DeleteAuthorCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }
    }
}