
namespace BackEnd.Repository;

public abstract  class RepositoryG<T>: IRepository<T> where T : class
{
    protected RepositoryG(OrderContext context)
    {
        _context = context;
        dbSet =context.Set<T>();
    }
    private OrderContext _context ;
    private DbSet<T> dbSet ;   
    public async Task<bool> Add(T entity)
    {
        await dbSet.AddAsync(entity);
        return true;
    }
    public async Task<IEnumerable<T>> All()
    {
       var result = await dbSet.ToListAsync();
        if(result.Count == 0) { return null; }
        return result;
    }
    public async Task<bool> Delete(object id)
    {
        var result = await dbSet.FindAsync(id);
        if(result != null)
        {
            dbSet.Remove(result);
            return true;
        }    
        else { return false; }
    }
    public async Task<T> GetById(object id)
    {
        var result = await dbSet.FindAsync(id);
        if( result != null ) {  return result; }
        else { return null; }
    }
    public async Task<bool> Update(T entity)
    {
        var result = await dbSet.FindAsync(entity);
        if (result == null) { return false; }
        else
        {
            result = entity;
            dbSet.Update(result);
            return true;
        }
    }
}
