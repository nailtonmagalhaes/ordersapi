using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Enums;
using OrdersAPI.Models;
using OrdersAPI.Repositories.Interfaces;

namespace OrdersAPI.Controllers
{
    [Route("api/postalcodes")]
    public class PostaCodeRangeController : ACRUDController<PostalCodeRange, IPostalCodeRangeRepository>
    {
        [HttpGet]
        [Route("state/{fu}")]
        public async Task<ActionResult<List<PostalCodeRange>>> GetByState([FromServices] IPostalCodeRangeRepository repository, string fu)
        {
            return await repository.GetByFU(fu);
        }

        [HttpGet]
        [Route("{postalCode}")]
        public async Task<ActionResult<PostalCodeRange>> GetByPostalCode([FromServices] IPostalCodeRangeRepository repository, string postalCode)
        {
            var validationResult = await ValidatePostalCode(postalCode);

            switch (validationResult)
            {
                case EPostalCodeValidation.InvalidPostalCodeEntered:
                case EPostalCodeValidation.PostalCodeNotProvided:
                    return BadRequest(((DescriptionAttribute[])validationResult.GetType().GetField(validationResult.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false))[0].Description);
                case EPostalCodeValidation.ValidPostalCode:
                    long.TryParse(new string(postalCode.Where(x => char.IsDigit(x)).ToArray()), out long longPostalCode);
                    return await repository.GetByPostalCode(longPostalCode);
                    default:
                    return NotFound();
            }
        }

        private async Task<EPostalCodeValidation> ValidatePostalCode(string postalCode)
        {
            return await Task.Run(() =>
            {
                return string.IsNullOrEmpty(postalCode) ? EPostalCodeValidation.PostalCodeNotProvided : postalCode.Where(x => char.IsDigit(x)).Count() == 8 ? EPostalCodeValidation.ValidPostalCode : EPostalCodeValidation.InvalidPostalCodeEntered;
            });
        }
    }

}