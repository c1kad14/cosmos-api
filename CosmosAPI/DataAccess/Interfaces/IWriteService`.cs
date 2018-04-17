using System.Threading.Tasks;
using Domain.Interfaces;

namespace DataAccess.Interfaces
{
    public interface IWriteService<TEntity> where TEntity : class, IBaseEntity, new()
    {
	    Task<TEntity> AddAsync(TEntity entity);
	    Task<TEntity> UpdateAsync(TEntity entity);
	    Task DeleteAsync(string id);

	}
}
