using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjetoWeb_Stories.Filters;
using ProjetoWeb_Stories.Models;

namespace ProjetoWeb_Stories.Controllers
{
	public class UsuarioController : Controller
	{
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

			
				return Redirect("Postagem/Feed");
		

		}

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
