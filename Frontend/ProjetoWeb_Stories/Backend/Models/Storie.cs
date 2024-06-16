using ProjetoWeb_Stories.Enums;

namespace ProjetoWeb_Stories.Backend.Models
{
    public class Storie
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
