using System.Collections.Generic;
using System.Threading.Tasks;
using OrdersAPI.Models;

namespace OrdersAPI.Repositories.Interfaces
{
    public interface IPostalCodeRangeRepository : ICRUDRepository<PostalCodeRange>
    {
        Task<PostalCodeRange> GetByPostalCode(long postalCode);
        Task<List<PostalCodeRange>> GetByFU(string fu);
    }
}