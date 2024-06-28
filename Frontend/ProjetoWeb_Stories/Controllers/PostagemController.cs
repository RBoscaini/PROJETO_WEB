using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ProjetoWeb_Stories.Backend.Models;
using ProjetoWeb_Stories.Models;
using sistemasWebAula.Backend.HTTPClient;
using System.Text;

namespace ProjetoWeb_Stories.Controllers
{
	public class PostagemController : Controller
	{

        [HttpGet]
        public IActionResult Index()
        {
            Storie storie;

            APIHttpClient client;
            client = new APIHttpClient("http://localhost:5107/api/");

            storie = client.Get<Storie>("storie");

            return View(Mapping.StorieMapping.ToStorieConsulta(storie));
        }

        [HttpGet]
        public IActionResult Like(Guid storieId)
        {
            var usuarioLogado = ObterUsuarioLogado();

            APIHttpClient client;
            client = new APIHttpClient("http://grupo4.neurosky.com.br/api/");

            client.Post($"likes/story/{storieId}/{usuarioLogado.Id}", storieId);

            return Redirect($"Storie?selectedId={storieId}");
        }


        [HttpGet]
        public IActionResult NovoStory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoStory(IFormFile file)
        {
            var usuarioLogado = ObterUsuarioLogado();

            if (file == null || file.Length <= 0)
            {
                throw new UserFriendlyException("error");
            }
        
            // Converte a imagem para byte[]
            byte[] imageData = null;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                imageData = memoryStream.ToArray();
            }

            Storie newStory = new Storie();
            newStory.Id = new Guid();
            newStory.NumVisualização = 0;
            newStory.Situacao = Enums.SituacaoStorieEnum.Disponível;
            newStory.DataEnvio = DateTime.Now;
            newStory.Conteudo = imageData;
            newStory.IdUsuario = usuarioLogado.Id;
            newStory.Usuario = new Usuario();
            newStory.Usuario.Nome = usuarioLogado.Nome;
            newStory.Usuario.Id = usuarioLogado.Id;

            APIHttpClient client;
            client = new APIHttpClient("https://localhost:7061/api/");
            // client = new APIHttpClient("http://grupo2.neurosky.com.br/api/");

            var newGuid = client.Post<Storie>("Storie", newStory);

            ViewBag.Message = "Upload realizado com sucesso!";

            return Redirect("Feed");
        }

        public async  Task<IActionResult> Storie(string selectedId)
        {
            Storie storie;

            APIHttpClient client;
            client = new APIHttpClient("https://localhost:7061/api/");
             //client = new APIHttpClient("http://grupo2.neurosky.com.br/api/");

            storie = client.Get<Storie>("Storie/" + selectedId);

            await MostrarImagem(storie.Conteudo);
            ViewBag.Storie = storie;
            return View(Mapping.StorieMapping.ToStorieConsulta(storie));
        }


        private async Task<IActionResult> MostrarImagem(byte[] imagem)
        {
            if (imagem == null)
                return NotFound();

            // Converte os bytes da imagem para base64
            var base64 = Convert.ToBase64String(imagem);
            var imagemBase64 = $"data:image/png;base64,{base64}";

            ViewBag.ImagemBase64 = imagemBase64;

            return View();
        }

        public IActionResult Feed()
        {
            var usuarioLogado = ObterUsuarioLogado();
            ViewBag.UsuarioLogado = usuarioLogado;

            List<Storie> getStories = new List<Storie>();
            List<StoryModel> showStories = new List<StoryModel>();

            APIHttpClient client = new APIHttpClient("https://localhost:7061/api/");
                         // client = new APIHttpClient("http://grupo2.neurosky.com.br");

            client.Put<Storie>("Storie");

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


            // client = new APIHttpClient("http://grupo5.neurosky.com.br");
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
                Stories = x.Select(y => new {  y.Image, y.Date }),
                StorieId = x.FirstOrDefault().Id   
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

        private UsuarioModel? ObterUsuarioLogado() =>
           JsonConvert.DeserializeObject<UsuarioModel>(Encoding.UTF8.GetString(HttpContext.Session.Get("UsuarioLogado")));
    }
}
