using System.Threading.Tasks;
using OrdersAPI.DTO;
using OrdersAPI.Models;

namespace OrdersAPI.Repositories.Interfaces
{
    public interface IOrderRepository : ICRUDRepository<Order>
    {
        Task<OrderDTO> GetInvoice(string orderNumber);
    }
}