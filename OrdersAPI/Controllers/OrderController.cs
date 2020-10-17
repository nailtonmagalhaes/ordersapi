using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrdersAPI.DTO;
using OrdersAPI.Models;
using OrdersAPI.Repositories.Interfaces;

namespace OrdersAPI.Controllers
{
    [Route("api/orders")]
    public class OrderController : ACRUDController<Order, IOrderRepository>
    {
        [HttpGet]
        [Route("")]
        public override async Task<ActionResult<List<Order>>> Get([FromServices] IOrderRepository repository)
        {
            return await repository.Get(x => x.Customer, x => x.Items);
        }

        [HttpGet]
        [Route("{id:int}")]
        public override async Task<ActionResult<Order>> GetByID([FromServices] IOrderRepository repository, int id)
        {
            return await repository.GetByID(x => x.ID == id, x => x.Customer, x => x.Items);
        }

        [HttpGet]
        [Route("invoice/{orderNumber}")]
        public async Task<ActionResult<OrderDTO>> GetInvoice([FromServices] IOrderRepository repository, string orderNumber)
        {
            return await repository.GetInvoice(orderNumber);
        }
    }
}