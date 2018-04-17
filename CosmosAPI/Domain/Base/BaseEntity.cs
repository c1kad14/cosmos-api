using Domain.Interfaces;
using Newtonsoft.Json;

namespace Domain.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }
	}
}
