using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Latt_Library.Models;

namespace Latt_Library.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Latt_Library.Models.Book> Book { get; set; }
        public DbSet<Latt_Library.Models.BookLender> BookLender { get; set; }
    }
}