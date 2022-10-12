using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Speedy.Models
{
    [Table("ExpenseType")]
    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "ExpenseType name")]
        public string ExpenseTypeName { get; set; }
    }
}
