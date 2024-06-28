using ProjetoWeb_Stories.Models;

namespace ProjetoWeb_Stories.Backend.Adapter
{
    public static class UsuarioAdapter
    {
        public static UsuarioModel ToUsuarioModel(UsuarioCadastroModel usuarioCadastro)
        {
            return new()
            {
                Nome = usuarioCadastro.Nome,
                Sobrenome = usuarioCadastro.Sobrenome,
                Email = usuarioCadastro.Email,
                Senha = usuarioCadastro.Senha!,
                DataComemorativa = usuarioCadastro.DataComemorativa,
                Bio = string.Empty,
                FotoPerfil = string.Empty,
                Cidade = string.Empty,
                Telefone = string.Empty,
                Documento = string.Empty,
            };
        }

          public static UsuarioCadastroModel ToUsuarioCadastroModel(UsuarioModel usuarioModel)
        {
            return new()
            {
                Nome = usuarioModel.Nome,
                Sobrenome = usuarioModel.Sobrenome,
                Email = usuarioModel.Email,
                DataComemorativa = usuarioModel.DataComemorativa
            };
        }

        public static UsuarioLoginModel ToUsuarioLoginModel(LoginModel login)
        {
            return new UsuarioLoginModel()
            {
                Email = login.Email,
                Senha = login.Senha,
            };
        }
    }
}
