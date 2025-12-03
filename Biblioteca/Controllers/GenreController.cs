using Biblioteca.Models;
using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class GenreController : Controller
    {
        //DI
        private readonly IGenreService _genreService;

        public GenreController(IGenreService service)
        {
            _genreService = service;
        }

        //CREATE
        [HttpPost]
        public async Task<IActionResult> Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                await _genreService.CreateAsync(genre);
                return RedirectToAction(nameof(Index));

            }
            return View(genre);
        }

        //READ
        public async Task<IActionResult> Index()
        {
            var genres = await _genreService.GetAllAsync();
            return View(genres);
        }
        //UPDATE

        //DELETE

    }
}