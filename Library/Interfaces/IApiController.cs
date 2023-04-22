using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Interfaces
{
    public interface IApiController<T> where T : IEntity
    {
        /// <summary>
        /// Efface une collection
        /// </summary>
        /// <returns></returns>
        Task<ActionResult> DropCollectionAsync();

        /// <summary>
        /// Compte le nombre d'enregistrement dans la collection
        /// </summary>
        /// <returns></returns>
        Task<long> CountDataAsync();

        /// <summary>
        /// Cré un enregistrement
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<ActionResult<T>> CreateAsync(T entity);

        /// <summary>
        /// Cré plusieurs enregistrements
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<ActionResult<IEnumerable<T>>> CreateManyAsync(IEnumerable<T> entities);

        /// <summary>
        /// Retourne tous les enregistrements
        /// </summary>
        /// <returns></returns>
        Task<ActionResult<IEnumerable<T>>> GetAllAsync();

        /// <summary>
        /// Retour un object complet avec ses Foreignkey et ses listes dépendants d'autres objects
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionResult<T>> GetOneFullAsync(string id);

        /// <summary>
        /// Retourne un object simple
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionResult<T>> GetOneSimpleAsync(string id);

        /// <summary>
        /// Met à jour un object
        /// </summary>
        /// <param name="entityUpdate"></param>
        /// <returns></returns>
        Task<ActionResult<T>> UpdateAsync(T entityUpdate);

        /// <summary>
        /// Efface un object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionResult> DeleteOneAsync(string id);

    }
}
