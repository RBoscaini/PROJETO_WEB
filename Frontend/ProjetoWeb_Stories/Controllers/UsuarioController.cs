using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using ProjetoWeb_Stories.Backend.Adapter;
using ProjetoWeb_Stories.Backend.Models;
using ProjetoWeb_Stories.Filters;
using ProjetoWeb_Stories.Models;
using sistemasWebAula.Backend.HTTPClient;
using System.Text;

namespace ProjetoWeb_Stories.Controllers
{
	public class UsuarioController : Controller
	{
        private static readonly string URLBase = "http://grupo3.neurosky.com.br/api/";

        public IActionResult Index()
        {
            return View("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
               // return Redirect("Postagem/Feed");
                var apiModel = UsuarioAdapter.ToUsuarioLoginModel(login);
                var retorno = new APIHttpClient(URLBase).Post<UsuarioLoginModel, UsuarioModel>("Usuario/Login", apiModel);

                if (retorno is not null)
                {
                    HttpContext.Session.Set("UsuarioLogado", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(retorno)));
                    ViewBag.UsuarioLogado = UsuarioAdapter.ToUsuarioCadastroModel(retorno);
                    return Redirect("Postagem/Feed");
                }
                else
                {
                    return this.Index();
                }
            }
            else
            {
                return this.Index();
            }

        }


        // -----
        public IActionResult Cadastrar()
		{
			return View();
		}
		
		[ServiceFilter(typeof(ExceptionFilter))]
		public IActionResult Erro()
		{
			throw new Exception("Teste teste");
		}
	}
}
