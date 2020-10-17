using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrdersAPI.Data;
using OrdersAPI.Models;
using OrdersAPI.Repositories.Interfaces;

namespace OrdersAPI.Repositories
{
    public class CustomerRepository : ACRUDRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context) { }

        public async Task<Customer> GetOrders(int id)
        {
            return await DbSet.Include(x => x.Phones).Include(x => x.Adresses).Include(x => x.Orders).SingleOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Order> GetOrder(int customerID, int orderID)
        {
            return await Context.Orders.Include(x => x.Items).SingleOrDefaultAsync(x => x.ID == orderID && x.CustomerID == customerID);
        }
    }
}