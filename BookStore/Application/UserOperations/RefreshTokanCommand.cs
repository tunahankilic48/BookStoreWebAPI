using AutoMapper;
using BookStore.DbOperations;
using BookStore.Model;
using BookStore.TokenOperations;
using BookStore.TokenOperations.Models;

namespace BookStore.Application.UserOperations
{
    public class RefreshTokanCommand
    {
        public string RefreshToken { get; set; }
        private readonly IBookStoreContext _context;
        private readonly IConfiguration _configuration;

        public RefreshTokanCommand(IBookStoreContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Token Handle()
        {
            User? user = _context.Users.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
            if (user is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();

                return token;
            }
            else
                throw new InvalidOperationException("Valid Bir Refresh Token bulunamadı.");

        }
    }
}
