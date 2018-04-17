using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Interfaces;
using Domain.Interfaces;
using Microsoft.Azure.Documents.Client;

namespace DataAccess
{
	public class ReadDataService<TEntity> : IReadService<TEntity> where TEntity : class, IBaseEntity, new()
	{
		protected DocumentClient Client;

		public ReadDataService(string endpointUri, string primaryKey, string database, string collection)
		{
			Database = database;
			Collection = collection;
			Client = new DocumentClient(new Uri(endpointUri), primaryKey);
		}

		public string Database { get; }
		public string Collection { get; }

		public List<TEntity> Get()
		{
			var queryOptions = new FeedOptions { MaxItemCount = -1 };
			
			var entities = Client.CreateDocumentQuery<TEntity>(
					UriFactory.CreateDocumentCollectionUri(Database, Collection), queryOptions).ToList();

			return entities;

		}

		public TEntity Get(string id)
		{
			var queryOptions = new FeedOptions { MaxItemCount = 1 };
			TEntity entity = null;
			try
			{
				entity = Client
				.CreateDocumentQuery<TEntity>(UriFactory.CreateDocumentCollectionUri(Database, Collection), queryOptions)
				.Where(e => e.Id == id)
				.ToList()
				.FirstOrDefault();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return entity;
		}
	}
}
