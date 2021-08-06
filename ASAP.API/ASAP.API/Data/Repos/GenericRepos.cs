using ASAP.API.Data.IRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.API.Data.Repos
{
    public class GenericRepos<T> : IGenericRepos<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        public GenericRepos(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T t)
        {
            await _context.Set<T>().AddAsync(t);
            await _context.SaveChangesAsync();
            return t;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id != default(int))
            {
                T t = await GetByIdAsync(id);
                if (t != default(T))
                {
                    _context.Set<T>().Remove(t);
                    await CommitAsync();
                }
            }
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T t)
        {
            _context.Entry<T>(t).State = EntityState.Modified;
            await CommitAsync();
            return t;
        }
    }
}
