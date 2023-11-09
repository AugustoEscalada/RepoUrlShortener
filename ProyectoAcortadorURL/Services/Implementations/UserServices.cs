using ProyectoAcortadorURL.Data;
using ProyectoAcortadorURL.Data.Models;
using ProyectoAcortadorURL.Entities;
using ProyectoAcortadorURL.Services.Interfaces;

namespace ProyectoAcortadorURL.Services.Implementations
{
    public class UserServices : IUserService
    {
        private UrlShortenerContext _context;
        public UserServices(UrlShortenerContext context)
        {
            _context = context;
        }

        public User? ValidateUser(AuthDto AuthDto)
        {
            return _context.Users.FirstOrDefault(p => p.Username == AuthDto.Username && p.Password == AuthDto.Password);

        }

        public void Create(UserForCreationDTO dto)
        {
            User newUser = new User()
            {
                Username = dto.Username,
                Password = dto.Password
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

    }
}
