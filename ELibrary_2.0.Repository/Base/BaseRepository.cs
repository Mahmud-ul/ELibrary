using ELibrary_2._0.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary_2._0.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ELibrary2DB _db;
        public BaseRepository()
        {
            _db = new ELibrary2DB();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }
        public async Task<T?> GetById(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }
        public async Task<bool> Create(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
