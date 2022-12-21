using Contacts.DBContext;
using Contacts.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers
{
    public class InfoController : Controller
    {
        private readonly InfoDBContext _db;

        public InfoController(InfoDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Infos.ToList());
        }

        //HTTP Get Method
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Info info)
        {
            var exists = _db.Infos.Any(x=>x.Contact==info.Contact || x.Email==info.Email);
            if (ModelState.IsValid)
                if (!exists)
                   {
                     _db.Add(info);
                     _db.SaveChanges();
                     return RedirectToAction(nameof(Index));
                   }
                else { TempData["Message"] = "Same Phone number or Email is entered"; }

            return View(info);
        }

        //HTTP Get Method
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _db.Infos.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Info obj)
        {
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var item = _db.Infos.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _db.Infos.Remove(item);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
