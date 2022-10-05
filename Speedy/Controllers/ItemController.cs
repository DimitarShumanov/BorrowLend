using Microsoft.AspNetCore.Mvc;
using Speedy.Data;
using Speedy.Models;
using System.Security.Cryptography.X509Certificates;

namespace Speedy.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<BorrowLend> obj = _db.BorrowLend;
            return View(obj);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BorrowLend item)
        {
            _db.BorrowLend.Add(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            var obj = _db.BorrowLend.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(BorrowLend obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            _db.BorrowLend.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var obj = _db.BorrowLend.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(BorrowLend obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            _db.BorrowLend.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
