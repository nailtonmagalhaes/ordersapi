using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Models;
using OrdersAPI.Repositories.Interfaces;

namespace OrdersAPI.Controllers
{
    [Route("api/products")]
    public class ProductController : ACRUDController<Product, IProductRepository>
    {
        [HttpGet]
        [Route("category/{categoryID:int}")]
        public async Task<ActionResult<Category>> GetByCategory([FromServices] IProductRepository repository, int categoryID)
        {
            return await repository.GetByCategory(categoryID);
        }
    }
}