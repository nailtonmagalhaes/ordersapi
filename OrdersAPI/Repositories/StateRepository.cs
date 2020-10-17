using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrdersAPI.Data;
using OrdersAPI.Models;
using OrdersAPI.Repositories.Interfaces;

namespace OrdersAPI.Repositories
{
    public class StateRepository : ACRUDRepository<State>, IStateRepository
    {
        public StateRepository(DataContext context) : base(context) { }

        public async Task<State> GetByFU(string FU)
        {
            var result = await DbSet.Include(x => x.PostalCodeRanges).FirstOrDefaultAsync(x => x.FU.ToLower() == FU.ToLower());
            return result;
        }
    }
}