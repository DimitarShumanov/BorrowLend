using Microsoft.AspNetCore.Mvc;
using Speedy.Data;
using Speedy.Models;
using Speedy.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.X509Certificates;


namespace Speedy.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> obj = _db.Expense;
            return View(obj);
        }

        public IActionResult Create()
        {
            ExpenseVM expenseVM = new ExpenseVM
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseType.Select(i => new SelectListItem
                {
                    Text = i.ExpenseTypeName,
                    Value = i.Id.ToString()
                })
            };
            return View(expenseVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(ExpenseVM expenseVM)
        {
            if(ModelState.IsValid)
            {
                _db.Expense.Add(expenseVM.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseVM);
        }

        public IActionResult Update(int? id)
        {
            var obj = _db.Expense.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(ExpenseVM expenseVM)
        {
            if (expenseVM == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _db.Expense.Update(expenseVM.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseVM);
        }

        public IActionResult Delete(int? id)
        {
            var obj = _db.Expense.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(ExpenseVM expenseVM)
        {
            if (expenseVM == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _db.Expense.Remove(expenseVM.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseVM);
        }
    }
}

