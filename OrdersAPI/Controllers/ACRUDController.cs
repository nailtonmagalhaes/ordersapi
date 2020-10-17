using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Models;
using OrdersAPI.Repositories.Interfaces;
using OrdersAPI.ViewModels;

namespace OrdersAPI.Controllers
{
    [ApiController]
    public abstract class ACRUDController<TEntity, TRepository> : ControllerBase
    where TEntity : BaseEntity
    where TRepository : ICRUDRepository<TEntity>
    {
        [HttpGet]
        [Route("")]
        public virtual async Task<ActionResult<List<TEntity>>> Get([FromServices] TRepository repository)
        {
            return await repository.Get();
        }

        [HttpGet]
        [Route("{id:int}")]
        public virtual async Task<ActionResult<TEntity>> GetByID([FromServices] TRepository repository, int id)
        {
            return await repository.GetByID(x => x.ID == id);
        }

        [HttpPost]
        [Route("")]
        public virtual async Task<ActionResult<ResultViewModel>> Post([FromServices] TRepository repository,
                                                                      [FromBody] TEntity entity)
        {
            if (ModelState.IsValid)
            {
                await repository.Insert(entity);
                return new ResultViewModel()
                {
                    Success = true,
                    Message = "The register was created successfully",
                    Data = entity
                };
            }
            else
            {
                return new ResultViewModel()
                {
                    Success = false,
                    Message = "Could not create the register",
                    Data = ModelState
                };
            }
        }

        [HttpPut]
        [Route("")]
        public virtual async Task<ActionResult<ResultViewModel>> Put([FromServices] TRepository repository,
                                                                     [FromBody] TEntity entity)
        {
            if (ModelState.IsValid)
            {
                await repository.Update(entity);
                return new ResultViewModel()
                {
                    Success = true,
                    Message = "The register was successfully saved",
                    Data = entity
                };
            }
            else
            {
                return new ResultViewModel()
                {
                    Success = false,
                    Message = "Could not save the register",
                    Data = ModelState
                };
            }
        }

        [HttpDelete]
        [Route("")]
        public virtual async Task<ActionResult<TEntity>> Delete([FromServices] TRepository repository,
                                                                [FromBody] TEntity entity)
        {
            await repository.Delete(entity);
            return entity;
        }
    }
}