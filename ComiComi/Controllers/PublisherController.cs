using ComiComi.Data;
using ComiComi.Data.Services;
using ComiComi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComiComi.Controllers
{
    [Authorize(Roles ="Admin")]
    public class PublisherController : Controller
    {
        private readonly IPublisherService _service;

        public PublisherController(IPublisherService service)
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
        public async Task<IActionResult> Create([Bind("PublisherName")] Publisher publisher)
        {
            if(!ModelState.IsValid) return View(publisher);
            await _service.AddAsync(publisher);
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null) return View("NotFound");
            return View(publisherDetails);  
        }

        public async Task<IActionResult> Edit(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null) return View("NotFound");
            return View(publisherDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Publisher publisher)
        {
            if (!ModelState.IsValid) return View(publisher);

            if(id == publisher.Id)
            {
                await _service.UpdateAsync(id, publisher);
                return RedirectToAction(nameof(Index));
            }            
            return View("NotFound");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null) return View("NotFound");
            return View(publisherDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null) return View("Not Found");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }




    }
}
