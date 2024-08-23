using CRUD_For_PDRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_For_PDRepository.DbContextProducts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
