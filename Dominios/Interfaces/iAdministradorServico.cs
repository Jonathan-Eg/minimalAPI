using MinimalAPI.Dominios.DTO;
using MinimalAPI.Dominios.Entidades;

namespace Minimal_API.Dominios.Interfaces
{
    public interface IAdministradorServico
    {
       Administrador Login(LoginDTO loginDTO);
        object Login(Program.LoginDTO loginDTO);
    }
}
