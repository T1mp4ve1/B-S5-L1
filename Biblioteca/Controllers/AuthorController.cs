using Biblioteca.Models;
using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class AuthorController : Controller
    {
        //DI
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        //CREATE: POST
        [HttpPost]
        public async Task<IActionResult> Create(Author author)
        {
            if (ModelState.IsValid)
            {
                await _authorService.CreateAsync(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        //READ: All
        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAllAsync();
            return View(authors);
        }

        //READ: ID
        public async Task<IActionResult> Details(Guid id)
        {
            var author = await _authorService.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        //UPDATE: POST
        [HttpPost]
        public async Task<IActionResult> Edit(Author author, Guid id)
        {
            if (ModelState.IsValid)
            {
                await _authorService.UpdateAsync(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        //DELETE: POST
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _authorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
