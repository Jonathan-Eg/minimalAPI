using Minimal_API.Dominios.Interfaces;
using MinimalAPI.Dominios.DTO;
using MinimalAPI.Dominios.Entidades;
using MinimalAPI.Infraestrutura.Db;

namespace Minimal_API.Dominios.Servicos
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly DbContexto _contexto;
        public AdministradorServico(DbContexto contexto)
        {
            _contexto = contexto;
        }
        public Administrador Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();

            return adm; 
            
        }

        public object Login(Program.LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }
    }
}
