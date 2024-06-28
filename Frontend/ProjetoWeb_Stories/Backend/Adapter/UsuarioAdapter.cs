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
            };
        }

          public static UsuarioCadastroModel ToUsuarioCadastroModel(UsuarioModel usuarioModel)
        {
            return new()
            {
                Id = usuarioModel.Id,
                Nome = usuarioModel.Nome,
                Sobrenome = usuarioModel.Sobrenome,
                Email = usuarioModel.Email,
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
