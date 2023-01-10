using Microsoft.AspNetCore.Mvc;
using MovieApplication.Data;
using MovieApplication.Data.Services;
using MovieApplication.Models;

namespace MovieApplication.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allActors= await _service.GetAllAsync();
            return View(allActors);
        }
        //Get :Actors/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {

                return View(actor);

            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        //Get : Actors/Details/1
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null)
                return View("Not Found");
            return View(actorDetails);
        }
        //Get :Actors/Edit/1
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null)
                return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {

                return View(actor);

            }
            await _service.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }

        //Get :Actors/Delete/1
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null)
                return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null)
                return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
