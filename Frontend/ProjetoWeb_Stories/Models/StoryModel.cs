namespace ProjetoWeb_Stories.Models
{
    public class StoryModel
    {
        public StoryModel(Guid id, Guid userId, byte[] image, DateTime date, string userName)
        {
            Id = id;
            UserId = userId;
            Image = image;
            Date = date;
            UserName = userName;
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public byte[] Image { get; set; }

        public DateTime Date { get; set; }
    }
}
