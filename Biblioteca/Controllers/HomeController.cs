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
        public async Task<IActionResult> Index()
        {
            var books = await _service.GetAllAsync();
            return View(books);
        }
    }
}
