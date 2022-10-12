using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Speedy.Models
{
    [Table("Expense")]
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Expense name")]
        public string ExpenseName { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "The amount must be positive number")]
        public double Amount { get; set; }
        public int ExpenseTypeId { get; set; }
        [ForeignKey("ExpenseTypeId")]
        public virtual ExpenseType ExpenseType { get; set; }

    }
}
