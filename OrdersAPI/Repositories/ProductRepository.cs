using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrdersAPI.Data;
using OrdersAPI.Models;
using OrdersAPI.Repositories.Interfaces;

namespace OrdersAPI.Repositories
{
    public class ProductRepository : ACRUDRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context) { }

        public async Task<Category> GetByCategory(int categoryID)
        {
            var result = await Context.Categories.Include(x => x.Products).AsNoTracking().SingleOrDefaultAsync(x => x.ID == categoryID);
            return result;
        }
    }
}