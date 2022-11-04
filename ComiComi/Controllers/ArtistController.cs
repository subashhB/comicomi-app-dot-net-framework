using ComiComi.Data;
using ComiComi.Data.Services;
using ComiComi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComiComi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ArtistController : Controller
    {
        private readonly IArtistService _service;
        public ArtistController(IArtistService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ArtistName,Bio")] Artist artist)
        {
            if(!ModelState.IsValid) return View(artist); 
            await _service.AddAsync(artist);
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var artistDetails = await _service.GetByIdAsync(id);
            if (artistDetails == null) return View("NotFound");
            return View(artistDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var artistDetails = await _service.GetByIdAsync(id);
            if (artistDetails != null) return View("NotFound");
            return View(artistDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Artist artist)
        {
            if (!ModelState.IsValid) return View(artist);
            await _service.UpdateAsync(id, artist);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var artistDetails = await _service.GetByIdAsync(id);
            if (artistDetails != null) return View("NotFound");
            return View(artistDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var artistDetails = await _service.GetByIdAsync(id);
            if (artistDetails != null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
