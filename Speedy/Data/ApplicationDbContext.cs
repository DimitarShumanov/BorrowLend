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
    }
}
