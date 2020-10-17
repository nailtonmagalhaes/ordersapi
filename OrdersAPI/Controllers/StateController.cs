using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Models;
using OrdersAPI.Repositories.Interfaces;

namespace OrdersAPI.Controllers
{
    [Route("api/states")]
    public class StateController : ACRUDController<State, IStateRepository>
    {
        [HttpGet]
        [Route("{fu}")]
        public async Task<ActionResult<State>> GetByFU([FromServices] IStateRepository repository, string fu)
        {
            return await repository.GetByFU(fu);
        }

        [HttpGet]
        [Route("")]
        public async override Task<ActionResult<List<State>>> Get([FromServices] IStateRepository repository)
        {
            return await repository.Get(x => x.PostalCodeRanges);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async override Task<ActionResult<State>> GetByID([FromServices] IStateRepository repository, int id)
        {
            return await repository.GetByID(x => x.ID == id, x => x.PostalCodeRanges);
        }
    }
}