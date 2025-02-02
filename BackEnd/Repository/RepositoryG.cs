
namespace BackEnd.Repository;

public abstract class RepositoryG<T> : IRepository<T> where T : class
{
    protected RepositoryG(InvoiceContext context)
    {
        _context = context;
        dbSet = context.Set<T>();
    }
    private InvoiceContext _context;
    private DbSet<T> dbSet;
    public async Task<bool> Add(T entity)
    {
        try
        {
            await dbSet.AddAsync(entity);
            return true;
        }
        catch (Exception ex) 
        {
            return false;
        }
    }
    public async Task<IEnumerable<T>> All()
    {
        var result = await dbSet.ToListAsync();
        if (result.Count == 0) { return null; }
        return result;
    }
    public async Task<bool> Delete(object id)
    {
        var result = await dbSet.FindAsync(id);
        if (result != null)
        {
            dbSet.Remove(result);
            return true;
        }
        else { return false; }
    }
    public async Task<T> GetById(object id)
    {
        var result = await dbSet.FindAsync(id);
        if (result != null) { return result; }
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
    public List<T> GetPaged<T>(int pageNumber, int pageSize = 10) where T : class
    {
        var dbSet = _context.Set<T>();

        var propertyInfo = typeof(T).GetProperty("Id");

        List<T> result = dbSet
            .OrderBy(e => EF.Property<object>(e, "Id"))  
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return result;
    }
}
