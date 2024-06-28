using Microsoft.AspNetCore.Mvc;
using ProjetoWeb_Stories.Backend.Models;
using ProjetoWeb_Stories.Models;
using sistemasWebAula.Backend.HTTPClient;

namespace ProjetoWeb_Stories.Controllers
{
	public class PostagemController : Controller
	{
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Index()
        {
            Storie storie;

            APIHttpClient client;
            client = new APIHttpClient("http://localhost:5107/api/");

            storie = client.Get<Storie>("storie");

            return View(Mapping.StorieMapping.ToStorieConsulta(storie));
        }

        public IActionResult Storie()
        {

            Storie storie;

            APIHttpClient client;
            client = new APIHttpClient("https://localhost:7061/api/");
           // client = new APIHttpClient("http://grupo2.neurosky.com.br");

            storie = client.Get<Storie>("Storie/62728556-d467-4724-8f11-7fed1490a20a");

            return View(Mapping.StorieMapping.ToStorieConsulta(storie));
            //return View("Storie");
        }

        
        public IActionResult Feed()
        {

            // Carregar os stories do banco de dados

            List<Storie> getStories = new List<Storie>();
            List<StoryModel> showStories = new List<StoryModel>();
         //   Storie storie = new Storie();
            APIHttpClient client;
            client = new APIHttpClient("https://localhost:7061/api/");
            // client = new APIHttpClient("http://grupo2.neurosky.com.br");

            getStories = client.GetAll<Storie>("Storie");

            foreach(Storie story in getStories)
            {
                StoryModel currentStorie = new StoryModel(
                    story.Id,
                    story.Usuario.Id,
                    story.Conteudo,
                    story.DataEnvio, 
                    story.Usuario.Nome
                );

                showStories.Add(currentStorie);

            }
            


            //    List <StoryModel> stories = new List<StoryModel>()
            //{
            //    new StoryModel(1, 1, "", DateTime.Now.AddHours(-1), "João Silva"),
            //    new StoryModel(2, 1, "", DateTime.Now.AddHours(-3), "Rodrigues Antunes"),
            //    new StoryModel(3, 2, "", DateTime.Now.AddHours(-2), "Marcio Mario"),
            //    new StoryModel(4, 3, "", DateTime.Now.AddHours(-3), "Rodrigo Moraes"),
            //    new StoryModel(5, 3, "", DateTime.Now.AddHours(-4), "Rodrigo Moraes"),
            //    new StoryModel(6, 4, "", DateTime.Now.AddHours(-3), "José Silva"),
            //    new StoryModel(7, 5, "", DateTime.Now.AddHours(-2), "Lara Silva"),
            //    new StoryModel(8, 6, "", DateTime.Now.AddHours(-5), "Jorge Pires"),
            //    new StoryModel(9, 7, "", DateTime.Now.AddHours(-2), "Silvano Moreira"),
            //    new StoryModel(11, 9, "", DateTime.Now.AddHours(-8), "Robson Dutra"),
            //    new StoryModel(10, 8, "", DateTime.Now.AddHours(-2), "Pietro Marcos"),
            //    new StoryModel(12, 10, "", DateTime.Now.AddHours(-3), "Mariana Silva"),
            //    new StoryModel(13, 11, "", DateTime.Now.AddHours(-2), "Rafael Lima"),

            //};

            List<PublicacaoModel> feedPosts = new List<PublicacaoModel>()
            {
                new PublicacaoModel()
                {
                    Id = 1,
                    UserId = 1,
                    Date =  DateTime.Now.AddHours(-1),
                    Likes = 2,
                    PostText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc sed hendrerit lacus, sit amet tempor velit. Nulla nec urna semper, tempus velit id, scelerisque tellus. Vestibulum interdum, erat vitae mollis semper, elit metus elementum sapien, at convallis nisl lorem vel lorem. Vestibulum malesuada nibh at ligula mattis, consequat iaculis diam elementum. Nunc euismod turpis eu accumsan scelerisque. Pellentesque eu pretium arcu. Donec maximus ligula eu felis pharetra, vel eleifend orci laoreet. Nulla non justo est. Nullam venenatis, est ac lacinia feugiat, augue tortor bibendum eros, et commodo ligula urna ac lorem. Mauris porttitor pharetra vehicula. Pellentesque ante nisi, gravida sed justo eu, sagittis volutpat ex. Nunc id felis mattis, congue sem quis, luctus lacus. Etiam id risus ut orci dignissim convallis pulvinar non urna. Duis vel nulla velit.",
                    UserName = "João Silva",
                    UserProfilePicture = "",
                    Comentarios = new List<Comentario>()
                    {
                        new Comentario()
                        {
                            Id = 1,
                            UserId = 2,
                            UserName = "Marcio Mario",
                            UserProfilePicture = "",
                            Date= DateTime.Now.AddHours(-1),
                            Likes= 3,
                            Text = "Concordo!"
                        }
                    }
                },
                new PublicacaoModel()
                {
                    Id = 1,
                    UserId = 1,
                    Date =  DateTime.Now.AddHours(-1),
                    Likes = 2,
                    PostText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc sed hendrerit lacus, sit amet tempor velit. Nulla nec urna semper, tempus velit id, scelerisque tellus. Vestibulum interdum, erat vitae mollis semper, elit metus elementum sapien, at convallis nisl lorem vel lorem. Vestibulum malesuada nibh at ligula mattis, consequat iaculis diam elementum. Nunc euismod turpis eu accumsan scelerisque. Pellentesque eu pretium arcu. Donec maximus ligula eu felis pharetra, vel eleifend orci laoreet. Nulla non justo est. Nullam venenatis, est ac lacinia feugiat, augue tortor bibendum eros, et commodo ligula urna ac lorem. Mauris porttitor pharetra vehicula. Pellentesque ante nisi, gravida sed justo eu, sagittis volutpat ex. Nunc id felis mattis, congue sem quis, luctus lacus. Etiam id risus ut orci dignissim convallis pulvinar non urna. Duis vel nulla velit.",
                    UserName = "João Silva",
                    UserProfilePicture = "",
                    Comentarios = new List<Comentario>()
                    {
                        new Comentario()
                        {
                            Id = 1,
                            UserId = 2,
                            UserName = "Marcio Mario",
                            UserProfilePicture = "",
                            Date= DateTime.Now.AddHours(-1),
                            Likes= 3,
                            Text = "Concordo!"
                        }
                    }
                },
                new PublicacaoModel()
                {
                    Id = 1,
                    UserId = 1,
                    Date =  DateTime.Now.AddHours(-1),
                    Likes = 2,
                    PostText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc sed hendrerit lacus, sit amet tempor velit. Nulla nec urna semper, tempus velit id, scelerisque tellus. Vestibulum interdum, erat vitae mollis semper, elit metus elementum sapien, at convallis nisl lorem vel lorem. Vestibulum malesuada nibh at ligula mattis, consequat iaculis diam elementum. Nunc euismod turpis eu accumsan scelerisque. Pellentesque eu pretium arcu. Donec maximus ligula eu felis pharetra, vel eleifend orci laoreet. Nulla non justo est. Nullam venenatis, est ac lacinia feugiat, augue tortor bibendum eros, et commodo ligula urna ac lorem. Mauris porttitor pharetra vehicula. Pellentesque ante nisi, gravida sed justo eu, sagittis volutpat ex. Nunc id felis mattis, congue sem quis, luctus lacus. Etiam id risus ut orci dignissim convallis pulvinar non urna. Duis vel nulla velit.",
                    UserName = "João Silva",
                    UserProfilePicture = "",
                    Comentarios = new List<Comentario>()
                    {
                        new Comentario()
                        {
                            Id = 1,
                            UserId = 2,
                            UserName = "Marcio Mario",
                            UserProfilePicture = "",
                            Date= DateTime.Now.AddHours(-1),
                            Likes= 3,
                            Text = "Concordo!"
                        }
                    }
                }


            };

            ViewBag.StoriesAgrupados = showStories.GroupBy(x => x.UserId).Select(x => new {
                UserId = x.Key,
                UserName = x.FirstOrDefault().UserName,
                LatestStoryDate = -(x.OrderBy(y => y.Date).FirstOrDefault().Date - DateTime.Now).Hours + " Horas Atrás",
                Stories = x.Select(y => new { y.Image, y.Date })
            }
            ).ToList();

            ViewBag.Posts = feedPosts;

            return View();  
        }

    
        public class Comentario
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
}
