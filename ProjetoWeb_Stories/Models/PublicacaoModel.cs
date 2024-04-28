using static ProjetoWeb_Stories.Controllers.PostagemController;

namespace ProjetoWeb_Stories.Models
{
    public class PublicacaoModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserProfilePicture { get; set; }
        public string PostText { get; set; }
        public int Likes { get; set; }
        public DateTime Date { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}
