using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Models;
using OrdersAPI.Repositories.Interfaces;

namespace OrdersAPI.Controllers
{
    [Route("api/categories")]
    public class CategoryController : ACRUDController<Category, ICategoryRepository>
    {
        [HttpGet]
        [Route("{id:int}/products")]
        public async Task<ActionResult<Category>> GetProducts([FromServices] ICategoryRepository repository, int id)
        {
            return await repository.GetByID(x => x.ID == id, x => x.Products);
        }
    }
}