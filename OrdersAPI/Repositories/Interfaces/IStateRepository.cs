using System.Threading.Tasks;
using OrdersAPI.Models;

namespace OrdersAPI.Repositories.Interfaces
{
    public interface IStateRepository : ICRUDRepository<State>
    {
        Task<State> GetByFU(string FU);
    }
}