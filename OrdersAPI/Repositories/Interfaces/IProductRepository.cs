using System.Collections.Generic;
using System.Threading.Tasks;
using OrdersAPI.Models;

namespace OrdersAPI.Repositories.Interfaces
{
    public interface IProductRepository : ICRUDRepository<Product>
    {
        Task<Category> GetByCategory(int categoryID);
    }
}