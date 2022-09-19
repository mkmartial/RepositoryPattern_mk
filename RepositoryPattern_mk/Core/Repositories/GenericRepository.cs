using RepositoryPattern_mk.Core.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryPattern_mk.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public Task<bool> Add(T entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> All()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
