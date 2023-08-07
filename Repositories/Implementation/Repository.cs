using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EConfirm.Data;
using EConfirm.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EConfirm.Repositories.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EConfirmDbContext _dbCOntext;
        private readonly DbSet<T> _table;

        public Repository(EConfirmDbContext dbContext)
        {
            _dbCOntext = dbContext;
            _table = _dbCOntext.Set<T>();
        }

        public async Task AddRange(List<T> model)
        {
            await _table.AddRangeAsync(model);
        }

        public async Task<T> Create(T model)
        {
            await _table.AddAsync(model);
            return model;
        }

        public async Task Delete(Guid id)
        {
            var item = await _table.FindAsync(id);
            if (item != null)
            {
                _table.Remove(item);
            }
        }

        public async Task<T> Get(Guid id)
        {
            return await _table.FindAsync(id);
            
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbCOntext.SaveChangesAsync() > 0;
        }

        public async Task<T> Update(T model)
        {
            _table.Update(model);
            return model;
        }

        public List<T> UpdateRange(List<T> model)
        {
            _table.UpdateRange(model);
            return model;
        }
    }
}
