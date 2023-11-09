using ProyectoAcortadorURL.Entities;
using ProyectoAcortadorURL.Data.Models;

namespace ProyectoAcortadorURL.Services.Interfaces
{
    public interface IUserService
    {
        void Create(UserForCreationDTO dto);

        User? ValidateUser(AuthDto AuthDto);
    }
}
