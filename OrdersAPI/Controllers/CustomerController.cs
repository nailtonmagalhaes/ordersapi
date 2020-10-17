using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Models;
using OrdersAPI.Repositories.Interfaces;

namespace OrdersAPI.Controllers
{
    [Route("api/customers")]
    public class CustomerController : ACRUDController<Customer, ICustomerRepository>
    {
        [HttpGet]
        [Route("")]
        public override async Task<ActionResult<List<Customer>>> Get([FromServices] ICustomerRepository repository)
        {
            return await repository.Get(x => x.Adresses, x => x.Phones);
        }

        [HttpGet]
        [Route("{id:int}")]
        public override async Task<ActionResult<Customer>> GetByID([FromServices] ICustomerRepository repository, int id)
        {
            return await repository.GetByID(x => x.ID == id, x => x.Adresses, x => x.Phones);
        }

        [HttpGet]
        [Route("{id:int}/orders")]
        public async Task<ActionResult<Customer>> GetOrders([FromServices] ICustomerRepository repository, int id)
        {
            return await repository.GetOrders(id);
        }

        [HttpGet]
        [Route("{customerID:int}/orders/{orderID:int}")]
        public async Task<ActionResult<Order>> GetOrder([FromServices] ICustomerRepository repository, int customerID, int orderID)
        {
            return await repository.GetOrder(customerID, orderID);
        }
    }
}