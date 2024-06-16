using ProjetoWeb_Stories.Backend.Models;
using ProjetoWeb_Stories.Enums;
using System.Drawing;

namespace ProjetoWeb_Stories.Models
{
    public class StorieConsultaModel
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }
        public byte[] Conteudo { get; set; }
        public DateTime DataEnvio { get; set; }
        public int NumVisualização { get; set; }
        public SituacaoStorieEnum Situacao { get; set; }
    }
}
