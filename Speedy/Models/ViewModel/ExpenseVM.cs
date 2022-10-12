using Microsoft.AspNetCore.Mvc.Rendering;

namespace Speedy.Models.ViewModel
{
    public class ExpenseVM
    {
        public Expense Expense { get; set; }

        public IEnumerable<SelectListItem> TypeDropDown { get; set; }
    }
}
