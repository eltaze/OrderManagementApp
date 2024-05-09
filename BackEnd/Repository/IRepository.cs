using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> All(); 
        Task<T> GetById(object id);
        Task<List<T>> GetByT(object id, string name);

        Task<bool> Add(T entity);

        Task<bool> Delete(object id);

        Task<bool> Update(T entity);
    }

}

