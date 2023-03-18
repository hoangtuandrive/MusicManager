using System.Linq.Expressions;

namespace MusicManager.Application.Interfaces.Repositories
{


    /// <summary>
    /// Interface for Base Repository.
    /// </summary>
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Gets a list of IQueryable objects.
        /// </summary>
        IQueryable<T> List();

        /// <summary>
        /// Retrieves a task by its id asynchronously. 
        /// </summary>
        /// <param name="id">The id of the task to retrieve.</param>
        Task<T> GetByIdAsync(int id);


        /// <summary>
        /// Gets all tasks asynchronously.
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync();


        /// <summary>
        /// Finds an IEnumerable based on the given Expression.
        /// </summary>
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);


        /// <summary>
        /// Adds the specified entity asynchronously.
        /// </summary>
        Task<bool> AddAsync(T entity);


        /// <summary>
        /// Adds a range of entities asynchronously.
        /// </summary>
        Task<bool> AddRangeAsync(IEnumerable<T> entities);


        /// <summary>
        /// Removes the specified entity from the collection.
        /// </summary>
        void Remove(T entity);


        /// <summary>
        /// Removes a range of entities from the collection.
        /// </summary>
        void RemoveRange(IEnumerable<T> entities);


        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(T entity);


        /// <summary>
        /// Asynchronously completes the task.
        /// </summary>
        Task<bool> CompleteAsync();


        /// <summary>
        /// Releases all resources used by the current instance of the Dispose class.
        /// </summary>
        void Dispose();
    }
}
