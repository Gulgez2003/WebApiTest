using Microsoft.EntityFrameworkCore;
using WebApiTest.Entities;

namespace WebApiTest.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet <Book> Books { get; set; }
    }


}
