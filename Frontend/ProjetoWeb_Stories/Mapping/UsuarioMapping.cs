using ProjetoWeb_Stories.Backend.Models;
using ProjetoWeb_Stories.Models;

namespace ProjetoWeb_Stories.Mapping
{
    public static class UsuarioMapping
    {
        public static UsuarioConsultaModel ToUsuarioConsulta(Usuario usuario)
        {
            UsuarioConsultaModel usuarioConsulta = new UsuarioConsultaModel();

            usuarioConsulta.Id = usuario.Id;
            usuarioConsulta.Nome = usuario.Nome;
            usuarioConsulta.Email = usuario.Email;
            usuarioConsulta.Senha = usuario.Senha;
            return usuarioConsulta;
        }
    }
}
