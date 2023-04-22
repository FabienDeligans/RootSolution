using Library.Interfaces;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Abstract
{
    [ApiController]
    public abstract class BaseApiController<T> : ControllerBase, IApiController<T> where T : IEntity
    {
        protected readonly IApiLogic<T> _apiLogic;

        public BaseApiController(IApiLogic<T> apiLogic)
        {
            _apiLogic = apiLogic;
        }

        [HttpDelete("DropCollectionAsync")]
        public virtual async Task<ActionResult> DropCollectionAsync()
        {
            await _apiLogic.DropCollectionAsync();
            return Ok();
        }

        [HttpGet("CountDataAsync")]
        public virtual async Task<long> CountDataAsync()
        {
            return await _apiLogic.CountDataAsync();
        }

        [HttpPost("CreateAsync")]
        public virtual async Task<ActionResult<T>> CreateAsync(T entity)
        {
            var result = await _apiLogic.CreateAsync(entity); 
            return new ActionResult<T>(result);
        }

        [HttpPost("CreateManyAsync")]
        public virtual async Task<ActionResult<IEnumerable<T>>> CreateManyAsync(IEnumerable<T> entities)
        {
            var result = await _apiLogic.CreateManyAsync(entities);
            return new ActionResult<IEnumerable<T>> (result);
        }

        [HttpGet("GetAllAsync")]
        public virtual async Task<ActionResult<IEnumerable<T>>> GetAllAsync()
        {
            var result = await _apiLogic.GetAllAsync();
            return new ActionResult<IEnumerable<T>>(result); 
        }

        [HttpGet("GetOneFullAsync")]
        public virtual async Task<ActionResult<T>> GetOneFullAsync(string id)
        {
            var result = await _apiLogic.GetOneFullAsync(id); 
            return new ActionResult<T>(result);
        }

        [HttpGet("GetOneSimpleAsync")]
        public virtual async Task<ActionResult<T>> GetOneSimpleAsync(string id)
        {
            var result = await _apiLogic.GetOneSimpleAsync(id);
            return new ActionResult<T>(result);
        }

        [HttpPut("UpdateAsync")]
        public virtual async Task<ActionResult<T>> UpdateAsync(T entityUpdate)
        {
            var result = await _apiLogic.UpdateAsync(entityUpdate);
            return new ActionResult<T>(result);
        }

        [HttpDelete("DeleteOneAsync")]
        public virtual async Task<ActionResult> DeleteOneAsync(string id)
        {
            await _apiLogic.DeleteOneAsync(id);
            return Ok(); 
        }
    }
}
