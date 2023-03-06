using AutoMapper;
using BookStore.Application.UserOperations;
using BookStore.DbOperations;
using BookStore.TokenOperations.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class UserController : Controller
    {
        private readonly IBookStoreContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserController(IBookStoreContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newuser)
        {
            CreateUserCommand command = new CreateUserCommand(_context, _mapper);
            command.Model = newuser;
            command.Handle();
            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper,_configuration);
            command.Model = login;
            var token = command.Handle();
            return token;
        }

        [HttpPost("refreshtoken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokanCommand command = new RefreshTokanCommand(_context, _configuration);
            command.RefreshToken = token;
            var resultTokan = command.Handle();
            return resultTokan;
        }
    }
}
