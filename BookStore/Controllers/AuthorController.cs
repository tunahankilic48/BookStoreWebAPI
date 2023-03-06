using AutoMapper;
using BookStore.Application.AuthorOperations.CreateAuthor;
using BookStore.Application.AuthorOperations.DeleteAuthor;
using BookStore.Application.AuthorOperations.GetAuthors;
using BookStore.Application.AuthorOperations.UpdateAuthor;
using BookStore.Application.BookOperations.CreateBook;
using BookStore.Application.BookOperations.DeleteBook;
using BookStore.Application.BookOperations.GetBooks;
using BookStore.Application.BookOperations.UpdateBook;
using BookStore.DbOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : Controller
    {
        private readonly IBookStoreContext _context;
        private readonly IMapper _mapper;

        public AuthorController(IBookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            query.AuthorId = id;
            try
            {
                GetAuthorsValidator validator = new GetAuthorsValidator();
                validator.ValidateAndThrow(query);
                var result = query.Handle(id);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = newAuthor;
            try
            {
                CreateAuthorCommandValidation validator = new CreateAuthorCommandValidation();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updatedAuthor)
        {

            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.Model = updatedAuthor;
            command.AuthorId = id;
            try
            {
                UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;
            try
            {
                DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
