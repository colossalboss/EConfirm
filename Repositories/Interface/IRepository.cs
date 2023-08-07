using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EConfirm.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T> Create(T model);
        Task AddRange(List<T> model);
        Task<T> Get(Guid id);
        IQueryable<T> GetAll();
        Task<T> Update(T model);
        List<T> UpdateRange(List<T> model);
        Task Delete(Guid id);
        Task<bool> SaveChangesAsync();
    }
}
