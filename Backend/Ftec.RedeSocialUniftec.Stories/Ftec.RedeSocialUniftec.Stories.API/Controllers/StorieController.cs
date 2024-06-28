using Ftec.RedeSocialUniftec.Stories.API.Adapter;
using Ftec.RedeSocialUniftec.Stories.API.Models;
using Ftec.RedeSocialUniftec.Stories.Application.Application;
using Ftec.RedeSocialUniftec.Stories.Application.Dto;
using Ftec.RedeSocialUniftec.Stories.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Ftec.RedeSocialUniftec.Stories.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorieController : Controller
    {
        [Description("Todos")]
        [HttpGet]
        public List<StorieModel> GetAll()
        {
            StorieApplication app = new StorieApplication();
            var storie = app.VisualizarTodos();

            List<StorieModel> listStorieModel = new List<StorieModel>();
            foreach(StorieDto sto in storie)
            {
                listStorieModel.Add(StorieMapping.ToModel(sto));    
            }

            return listStorieModel;
        }


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

        [Description("Temporizador")]
        [HttpPut]
        public void Put()
        {
            StorieApplication app = new StorieApplication();
            app.Temporizador();
        }

    }
}
