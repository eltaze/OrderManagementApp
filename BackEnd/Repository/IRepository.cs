
namespace BackEnd.Repository;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> All();
    Task<T> GetById(object id);

    Task<bool> Add(T entity);

    Task<bool> Delete(object id);

    Task<bool> Update(T entity);
     List<T> GetPaged<T>(int pageNumber, int pageSize = 10) where T : class;

}

