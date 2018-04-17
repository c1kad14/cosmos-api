using System.Collections.Generic;
using Domain.Interfaces;

namespace DataAccess.Interfaces
{
    public interface IReadService<TEntity> where TEntity : class, IBaseEntity, new()
    {
	    List<TEntity> Get();
	    TEntity Get(string id);
    }
}
