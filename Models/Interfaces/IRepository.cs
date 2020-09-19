using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<T> GetByName(Expression<Func<T, bool>> filter,
                                                Func<T, object> orderingFunction = null,
                                                bool orderingAsc = true,
                                                int skip = 0,
                                                int pageLength = -1);
    }
}
