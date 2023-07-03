using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SolarCoffe.Data.Repositories.Common
{
    /// <summary>
    /// Implementing repository pattern with common methods for CRUD operations
    /// </summary>
    /// <typeparam name="T">Represents response value to consumer</typeparam>
    public interface IRepository<T,E> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> FindAsync(Expression<Func<E, bool>> expression);
        Task<T> AddAsync(E entity);
        Task<T> UpdateAsync(E entity);
        Task<T> DeleteAsync(Guid id);
    }
}
