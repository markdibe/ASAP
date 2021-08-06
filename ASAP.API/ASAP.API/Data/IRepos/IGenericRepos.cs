using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.API.Data.IRepos
{
    public interface IGenericRepos<T> where T:class
    {
        Task<T> AddAsync(T t);

        Task<T> UpdateAsync(T t);

        Task DeleteAsync(int id);

        Task<T> GetByIdAsync(int id);

        IQueryable<T> Get();

        Task CommitAsync();
    }
}
