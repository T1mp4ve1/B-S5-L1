using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
