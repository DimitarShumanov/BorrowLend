using Microsoft.EntityFrameworkCore;
using Speedy.Models;
namespace Speedy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<BorrowLend> BorrowLend { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<ExpenseType> ExpenseType { get; set; }
    } 
}
