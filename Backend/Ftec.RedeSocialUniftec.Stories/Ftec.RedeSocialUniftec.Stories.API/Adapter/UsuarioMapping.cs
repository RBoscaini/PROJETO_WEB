using Ftec.RedeSocialUniftec.Stories.API.Models;
using Ftec.RedeSocialUniftec.Stories.Application.Dto;

namespace Ftec.RedeSocialUniftec.Stories.API.Adapter
{
    public class UsuarioMapping
    {
        public static UsuarioModel ToModel(UsuarioDto usuario)
        {
            if (usuario == null) return null;
            else
            {
                UsuarioModel usuarioModel = new UsuarioModel();
                usuarioModel.Id = usuario.Id;
                usuarioModel.Nome = usuario.Nome;
                
                return usuarioModel;
            }
        }

        public static UsuarioDto ToDto(UsuarioModel usuario)
        {
            if (usuario == null) return null;
            else
            {
                UsuarioDto usuarioDto = new UsuarioDto();
                usuarioDto.Id = usuario.Id;
                usuarioDto.Nome = usuario.Nome;

                return usuarioDto;
            }
        }
    }
}
