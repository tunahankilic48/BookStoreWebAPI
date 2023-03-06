using AutoMapper;
using BookStore.Application.BookOperations.CreateBook;
using BookStore.Application.BookOperations.DeleteBook;
using BookStore.Application.BookOperations.GetBooks;
using BookStore.Application.BookOperations.UpdateBook;
using BookStore.Application.GenreOperations.CreateGenre;
using BookStore.Application.GenreOperations.DeleteGenre;
using BookStore.Application.GenreOperations.GetGenres;
using BookStore.Application.GenreOperations.UpdateGenre;
using BookStore.DbOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : Controller
    {
        private readonly IBookStoreContext _context;
        private readonly IMapper _mapper;

        public GenreController(IBookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);

        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            query.GendreId = id;
            try
            {
                GetGenresValidator validator = new GetGenresValidator();
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
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = newGenre;
            try
            {
                CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
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
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updatedGenre)
        {

            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.Model = updatedGenre;
            command.GenreId = id;
            try
            {
                UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
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
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;
            try
            {
                DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
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
