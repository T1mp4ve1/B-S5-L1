using Biblioteca.Models;
using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Biblioteca.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISingleBookService _service;
        private readonly IGenreService _genre;
        private readonly IAuthorService _author;
        public AdminController(ISingleBookService service, IGenreService genre, IAuthorService author)
        {
            _service = service;
            _genre = genre;
            _author = author;
        }


        //CREATE
        [HttpPost]
        public async Task<IActionResult> Create(SingleBook book)
        {
            if (!ModelState.IsValid)
            {
                await PopulateSelect(book.AuthorID, book.GenreID);
                return View("Index", await _service.GetAllAsync());
            }
            await _service.CreateAsync(book);
            return RedirectToAction(nameof(Index));
        }

        //READ
        public async Task<IActionResult> Index()
        {
            await PopulateSelect();
            var allBooks = await _service.GetAllAsync();
            return View(allBooks);
        }

        private async Task PopulateSelect(Guid? selectedAuthor = null, int? selectedGenre = null)
        {
            var genres = await _genre.GetAllAsync();
            var authors = await _author.GetAllAsync();

            ViewBag.Genres = new SelectList(genres, "GenreID", "GenreName", selectedGenre);
            ViewBag.Authors = new SelectList(authors, "AuthorID", "Pseudonym", selectedAuthor);
        }

        //UPDATE

        //DELETE

    }
}
