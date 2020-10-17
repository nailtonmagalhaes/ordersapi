using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrdersAPI.Data;
using OrdersAPI.Models;
using OrdersAPI.Repositories.Interfaces;

namespace OrdersAPI.Repositories
{
    public class PostalCodeRangeRepository : ACRUDRepository<PostalCodeRange>, IPostalCodeRangeRepository
    {
        public PostalCodeRangeRepository(DataContext context) : base(context) { }

        public async Task<List<PostalCodeRange>> GetByFU(string fu)
        {
            return await DbSet.Include(x => x.State).Where(x => x.State.FU.ToLower() == fu.ToLower()).ToListAsync();
        }

        public async Task<PostalCodeRange> GetByPostalCode(long postalCode)
        {
            var result = await DbSet.Include(x => x.State).FirstOrDefaultAsync(x => ConvertPostalCodeToLong(x.Start).GetAwaiter().GetResult() <= postalCode &&
                                                                                    ConvertPostalCodeToLong(x.End).GetAwaiter().GetResult() >= postalCode);
            return result;
        }

        private async Task<long> ConvertPostalCodeToLong(string postalCode)
        {
            return await Task.Run(() =>
              {
                  long.TryParse(new string(postalCode.Where(x => Char.IsDigit(x)).ToArray()), out long res);
                  return res;
              });
        }
    }
}