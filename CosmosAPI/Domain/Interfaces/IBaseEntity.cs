using Newtonsoft.Json;

namespace Domain.Interfaces
{
    public interface IBaseEntity
	{
		[JsonProperty(PropertyName = "id")]
		string Id { get; set; }
	}
}
