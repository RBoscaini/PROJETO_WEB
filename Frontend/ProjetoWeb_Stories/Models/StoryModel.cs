namespace ProjetoWeb_Stories.Models
{
    public class StoryModel
    {
        public StoryModel(int id, int userId, string image, DateTime date, string userName)
        {
            Id = id;
            UserId = userId;
            Image = image;
            Date = date;
            UserName = userName;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }

        public DateTime Date { get; set; }
    }
}
