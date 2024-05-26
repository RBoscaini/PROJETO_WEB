namespace ProjetoWeb_Stories.Models
{
    public class ComentarioModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserProfilePicture { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
        public DateTime Date { get; set; }
    }
}
