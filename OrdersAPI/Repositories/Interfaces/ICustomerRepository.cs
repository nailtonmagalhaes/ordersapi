using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Models;

namespace OrdersAPI.Repositories.Interfaces
{
    public interface ICustomerRepository : ICRUDRepository<Customer>
    {
        Task<Customer> GetOrders(int id);
        Task<Order> GetOrder(int customerID, int orderID);
    }
}