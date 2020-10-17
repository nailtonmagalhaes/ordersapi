using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrdersAPI.Data;
using OrdersAPI.DTO;
using OrdersAPI.Models;
using OrdersAPI.Repositories.Interfaces;

namespace OrdersAPI.Repositories
{
    public class OrderRepository : ACRUDRepository<Order>, IOrderRepository
    {
        public OrderRepository(DataContext context) : base(context) { }

        public async Task<OrderDTO> GetInvoice(string orderNumber)
        {
            var invoice = await DbSet.Include(x => x.Items).ThenInclude(x => x.Product)
                                     .Include(x => x.Customer)
                                     .Include(x => x.Customer.Adresses).ThenInclude(x => x.State)
                                     .Include(x => x.Customer.Phones).AsNoTracking().SingleOrDefaultAsync(x => x.Number == orderNumber);
            if (invoice != null)
                return new OrderDTO()
                {
                    Customer = invoice.Customer.FullName,
                    Document = invoice.Customer.Document,
                    OrderNumber = invoice.Number,
                    PostalCode = invoice.Customer.Adresses.FirstOrDefault()?.PostalCode,
                    ShippingCost = invoice.ShippingCost,
                    FU = invoice.Customer.Adresses.FirstOrDefault()?.State.FU,
                    State = invoice.Customer.Adresses.FirstOrDefault()?.State.Name,
                    Items = invoice.Items.Select(x => new OrderItemDTO()
                    {
                        Product = x.Product.Description,
                        Quantity = x.Quantity,
                        UnitPrice = x.Product.UnitPrice,
                        TotalPrice = x.TotalPrice,
                    }).ToList()
                };
            return null;
        }
    }
}