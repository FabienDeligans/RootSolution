using Library.Models;

namespace Library.Interfaces
{
    public interface IApiServiceDatabase
    {
        Task DropCollectionAsync<T>() where T : IEntity;
        Task<long> CountDataAsync<T>() where T : IEntity;
        Task<T> CreateAsync<T>(T entity) where T : IEntity;
        Task<IEnumerable<T>> CreateManyAsync<T>(IEnumerable<T> entities) where T : IEntity;
        Task<IEnumerable<T>> GetAllAsync<T>() where T : IEntity;
        Task<T> GetOneAsync<T>(string? id) where T : IEntity;
        Task<T> UpdateAsync<T>(T entityUpdate) where T : IEntity;
        Task DeleteOneAsync<T>(string id) where T : IEntity;
        Task<T> GetEntityWithForeignKey<T>(T entity) where T : IEntity;
        Task<T> GetCollectionEntity<T>(T entity) where T : IEntity;
    }
}
