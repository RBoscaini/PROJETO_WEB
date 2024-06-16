using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.RedeSocialUniftec.Stories.Application.Dto
{
    public class StorieDto
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public byte[] Conteudo { get; set; }
        public DateTime DataEnvio { get; set; }
        public int NumVisualização { get; set; }
        public SituacaoStorieDto Situacao { get; set; }

    }

    public enum SituacaoStorieDto
    {
        Desativado = 1,
        Finalizado = 2,
        Disponível = 3,
        Arquivado = 4,
    }
}
