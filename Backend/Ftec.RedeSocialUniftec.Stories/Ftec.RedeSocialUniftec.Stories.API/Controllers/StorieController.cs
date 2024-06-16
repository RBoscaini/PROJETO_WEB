using Ftec.RedeSocialUniftec.Stories.API.Adapter;
using Ftec.RedeSocialUniftec.Stories.API.Models;
using Ftec.RedeSocialUniftec.Stories.Application.Application;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Ftec.RedeSocialUniftec.Stories.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorieController : Controller
    {
        [Description("Visualizar")]
        [HttpGet("{id:Guid}")]
        public StorieModel Get(Guid id)
        {
            StorieApplication app = new StorieApplication();
            var storie = app.Visualizar(id);
            return StorieMapping.ToModel(storie);
        }

        [Description("Postar")]
        [HttpPost]
        public Guid Post(StorieModel storie)
        {
            StorieApplication app = new StorieApplication();
            return app.Postar(StorieMapping.ToDto(storie));
        }

        [Description("Arquivar")]
        [HttpPost("{id:Guid}")]
        public void Post(Guid id)
        {
            StorieApplication app = new StorieApplication();
            app.Arquivar(id);
        }

        [Description("Excluir")]
        [HttpDelete("{id:Guid}")]
        public void Delete(Guid id)
        {
            StorieApplication app = new StorieApplication();
            app.Excluir(id);
        }

        //[Description("Temporizador")]
        //[HttpPost]
        //public void Temporizador()
        //{
        //    StorieApplication app = new StorieApplication();
        //    app.Temporizador();
        //}
    }
}
