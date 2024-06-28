using Ftec.RedeSocialUniftec.Stories.Application.Dto;
using Ftec.RedeSocialUniftec.Stories.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.RedeSocialUniftec.Stories.Application.Adapter
{
    public static class StorieAdapter
    {
        public static Storie ToDomain(StorieDto storie)
        {
            if (storie == null) return null;
            else
            {
                Storie storieDomain = new Storie();
                storieDomain.Conteudo = storie.Conteudo;
                storieDomain.NumVisualização = storie.NumVisualização;
                storieDomain.DataEnvio = storie.DataEnvio;
                storieDomain.Situacao = (SituacaoStorie)storie.Situacao;
                storieDomain.Id = storie.Id;
                storieDomain.IdUsuario = storie.IdUsuario;
                storieDomain.Usuario = storie.Usuario;

                return storieDomain;
            }
        }

        public static StorieDto ToDto(Storie storie)
        {
            if (storie == null) return null;
            else
            {
                StorieDto storieDto = new StorieDto();
                storieDto.Conteudo = storie.Conteudo;
                storieDto.NumVisualização = storie.NumVisualização;
                storieDto.DataEnvio = storie.DataEnvio;
                storieDto.Situacao = (SituacaoStorieDto)storie.Situacao;
                storieDto.Id = storie.Id;
                storieDto.IdUsuario = storie.IdUsuario;
                storieDto.Usuario = storie.Usuario;
                

                return storieDto;
            }
        }
    }
}
