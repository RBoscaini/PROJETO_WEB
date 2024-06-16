namespace Ftec.RedeSocialUniftec.Stories.API.Models
{
    public class StorieModel
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public byte[] Conteudo { get; set; }
        public DateTime DataEnvio { get; set; }
        public int NumVisualização { get; set; }
        public SituacaoStorieModel Situacao { get; set; }

    }

    public enum SituacaoStorieModel
    {
        Desativado = 1,
        Finalizado = 2,
        Disponível = 3,
        Arquivado = 4,
    }
}
