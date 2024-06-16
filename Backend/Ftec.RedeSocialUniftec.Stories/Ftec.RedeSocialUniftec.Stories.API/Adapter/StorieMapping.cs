using Ftec.RedeSocialUniftec.Stories.API.Models;
using Ftec.RedeSocialUniftec.Stories.Application.Dto;

namespace Ftec.RedeSocialUniftec.Stories.API.Adapter
{
    public static class StorieMapping
    {
        public static StorieModel ToModel(StorieDto storie)
        {
            if (storie == null) return null;
            else
            {
                StorieModel storieModel = new StorieModel();
                storieModel.Conteudo = storie.Conteudo;
                storieModel.Situacao = (SituacaoStorieModel)storie.Situacao;
                storieModel.NumVisualização = storie.NumVisualização;
                storieModel.DataEnvio = storie.DataEnvio;
                storieModel.Id = storie.Id;
                storieModel.IdUsuario = storie.IdUsuario;
                
                return storieModel;
            }
        }

        public static StorieDto ToDto(StorieModel storie)
        {
            if (storie == null) return null;
            else
            {
                StorieDto storieDto = new StorieDto();
                storieDto.Conteudo = storie.Conteudo;
                storieDto.Situacao = (SituacaoStorieDto)storie.Situacao;
                storieDto.NumVisualização = storie.NumVisualização;
                storieDto.DataEnvio = storie.DataEnvio;
                storieDto.Id = storie.Id;
                storieDto.IdUsuario = storie.IdUsuario;
                
                return storieDto;
            }
        }
    }
}
