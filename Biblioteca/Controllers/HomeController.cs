using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISingleBookService _service;

        public HomeController(ISingleBookService service)
        {
            _service = service;
        }

        //READ
        public IActionResult Index()
        {
            return View();
        }
    }
}
