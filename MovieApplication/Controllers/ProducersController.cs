using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApplication.Data;
using MovieApplication.Data.Services;
using MovieApplication.Models;

namespace MovieApplication.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service = service;
        }

        public async  Task<IActionResult> Index()
        {
            var allProducers= await _service.GetAllAsync();
            return View(allProducers);
        }

        //Get: Producers/Details/1
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails=await _service.GetByIdAsync(id);
            if(producerDetails==null)
                return View("NotFound");
            return View(producerDetails);
        }

        //Get : Producers/Create
        public IActionResult Create()
        {
            return View();
        }
        //Post: Producers/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }
        //Get : Producers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetail =await  _service.GetByIdAsync(id);
            if (producerDetail == null)
                return View("NotFound");
            return View(producerDetail);
        }
        //Post: Producers/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            if (id == producer.Id)
            {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }
        //Get : Producers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetail = await _service.GetByIdAsync(id);
            if (producerDetail == null)
                return View("NotFound");
            return View(producerDetail);
        }
        //Post: Producers/Edit/1
        [HttpPost, ActionName("Delete")]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetail = await _service.GetByIdAsync(id);
            if (producerDetail == null)
                return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
