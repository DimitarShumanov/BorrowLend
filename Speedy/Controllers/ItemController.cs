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
    }
}
