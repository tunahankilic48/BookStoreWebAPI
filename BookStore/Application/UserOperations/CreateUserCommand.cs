using AutoMapper;
using BookStore.Application.BookOperations.CreateBook;
using BookStore.DbOperations;
using BookStore.Model;

namespace BookStore.Application.UserOperations
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }
        private readonly IBookStoreContext _context;
        private readonly IMapper _mapper;

        public CreateUserCommand(IBookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            User? user = _context.Users.FirstOrDefault(x => x.Email == Model.Email);
            if (user is not null)
            {
                throw new InvalidOperationException("Kullanıcı zaten mevcut");
            }

            user = _mapper.Map<User>(Model);

            _context.Users.Add(user);
            _context.SaveChanges();

        }
    }
}
