using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.RedeSocialUniftec.Stories.Domain.Entities
{
    public class Storie
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public byte[] Conteudo {  get; set; }
        public DateTime DataEnvio { get; set; }
        public int NumVisualização { get; set; }
        public SituacaoStorie Situacao { get; set; }

    }

    public enum SituacaoStorie{
        Desativado = 1,
        Finalizado = 2,
        Disponível = 3,
        Arquivado = 4,
    }
}
