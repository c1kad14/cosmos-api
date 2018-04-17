using System;
using System.Net;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Domain.Interfaces;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace DataAccess
{
    public class WriteDataService<TEntity> : ReadDataService<TEntity>, IWriteService<TEntity> where TEntity : class, IBaseEntity, new()
    {
	    public WriteDataService(string endpointUri, string primaryKey, string database, string collection) : base(endpointUri, primaryKey, database, collection)
	    {
		    
	    }
	    public async Task<TEntity> AddAsync(TEntity entity)
		{
			var result = await Client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(Database, Collection), entity);
			return entity;
		}

	    public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			await Client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(Database, Collection, entity.Id), entity);
			return entity;
		}

	    public async Task DeleteAsync(string id)
		{
			await Client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(Database, Collection, id));

		}
	}
}
