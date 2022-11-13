using ComiComi.Data;
using ComiComi.Data.Services;
using ComiComi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComiComi.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ComicController : Controller
    {
        private readonly IComicService _service;
        public ComicController(IComicService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            

            return View(data);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _service.GetAllAsync(n => n.Artist , n=>n.Author , n => n.Publisher);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = data.Where(n => n.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase) || 
                    n.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    n.Artist.ArtistName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    n.Author.AuthorName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    n.Publisher.PublisherName.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
                if (filteredResult.Count < 1)
                    return View("NotFound");
                return View("Index",filteredResult); 
            }
            return View("Index",data);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var comicDetails = await _service.GetComicByIdAsync(id);
            return View(comicDetails);
        }
        
        public async Task<IActionResult> Create()
        {
            var comicDropDownData = await _service.GetComicDropDownValues();
            ViewBag.Authors = new SelectList(comicDropDownData.Authors, "Id", "AuthorName");
            ViewBag.Publishers = new SelectList(comicDropDownData.Publishers, "Id", "PublisherName");
            ViewBag.Artists = new SelectList(comicDropDownData.Artists, "Id", "ArtistName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewComicVM comic)
        {
            if (!ModelState.IsValid)
            {
                var comicDropDownData = await _service.GetComicDropDownValues();
                ViewBag.Authors = new SelectList(comicDropDownData.Authors, "Id", "AuthorName");
                ViewBag.Publishers = new SelectList(comicDropDownData.Publishers, "Id", "PublisherName");
                ViewBag.Artists = new SelectList(comicDropDownData.Artists, "Id", "ArtistName");
                return View(comic);
            }
            await _service.AddNewComic(comic);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var comicDetails = await _service.GetByIdAsync(id);
            if(comicDetails == null) return View("NotFound");

            var response = new NewComicVM()
            {
                Id = comicDetails.Id,
                Title = comicDetails.Title,
                CoverPhotoURL = comicDetails.CoverPhotoURL,
                Description = comicDetails.Description,
                Price = comicDetails.Price,
                Volume = comicDetails.Volume,
                Status = comicDetails.Status,
                Genre = comicDetails.Genre,
                Serializaton = comicDetails.Serializaton,
                Day = comicDetails.Day,
                AuthorId = comicDetails.AuthorId,
                ArtistId = comicDetails.ArtistId,
                PublisherId = comicDetails.PublisherId,

            };

            var comicDropDownData = await _service.GetComicDropDownValues();
            ViewBag.Authors = new SelectList(comicDropDownData.Authors, "Id", "AuthorName");
            ViewBag.Publishers = new SelectList(comicDropDownData.Publishers, "Id", "PublisherName");
            ViewBag.Artists = new SelectList(comicDropDownData.Artists, "Id", "ArtistName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewComicVM comic)
        {
            if (id != comic.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var comicDropDownData = await _service.GetComicDropDownValues();
                ViewBag.Authors = new SelectList(comicDropDownData.Authors, "Id", "AuthorName");
                ViewBag.Publishers = new SelectList(comicDropDownData.Publishers, "Id", "PublisherName");
                ViewBag.Artists = new SelectList(comicDropDownData.Artists, "Id", "ArtistName");
                return View(comic);
            }

            await _service.UpdateComicAsync(comic);
            return RedirectToAction(nameof(Index));
        }



        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var comicDetails = await _service.GetByIdAsync(id);
            if (comicDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
