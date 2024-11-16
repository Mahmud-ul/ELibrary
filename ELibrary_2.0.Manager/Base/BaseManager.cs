using ELibrary_2._0.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary_2._0.Manager.Base
{
    public class BaseManager<T> : IBaseManager<T> where T : class
    {
        protected readonly IBaseRepository<T> _repository;
        public BaseManager(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<T?> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task<bool> Create(T entity)
        {
            return await _repository.Create(entity);
        }
        public async Task<bool> Delete(T entity)
        {
            return await _repository.Delete(entity);
        }
        public async Task<bool> Update(T entity)
        {
            return await _repository.Update(entity);
        }
    }
}
