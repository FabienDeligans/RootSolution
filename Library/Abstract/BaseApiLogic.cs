using Library.Interfaces;
using Library.Models;

namespace FabApi.Logic
{
    public abstract class BaseApiLogic<T> : IApiLogic<T> where T : IEntity
    {
        protected readonly IApiServiceDatabase _service;

        protected BaseApiLogic(IApiServiceDatabase service)
        {
            _service = service;
        }

        public virtual async Task DropCollectionAsync()
        {
            await _service.DropCollectionAsync<T>();
        }

        public virtual async Task<long> CountDataAsync()
        {
            return await _service.CountDataAsync<T>();
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            entity.CreationDate = DateTime.Now;
            return await _service.CreateAsync<T>(entity);
        }

        public virtual async Task<IEnumerable<T>> CreateManyAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreationDate = DateTime.Now;
            }
            return await _service.CreateManyAsync(entities);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _service.GetAllAsync<T>();
        }

        public virtual async Task<T> GetOneFullAsync(string? id)
        {
            var entity = await _service.GetOneAsync<T>(id);

            entity = await _service.GetEntityWithForeignKey<T>(entity!)!;
            entity = await _service.GetCollectionEntity<T>(entity!)!;

            return entity;
        }

        public async Task<T> GetOneSimpleAsync(string id)
        {
            return await _service.GetOneAsync<T>(id);
        }

        public virtual async Task<T> UpdateAsync(T entityUpdate)
        {
            entityUpdate.UpdateDate = DateTime.Now;
            return await _service.UpdateAsync<T>(entityUpdate);
        }

        public virtual async Task DeleteOneAsync(string id)
        {
            await _service.DeleteOneAsync<T>(id);
        }
    }
}
