using Domain.Interfaces;
using Newtonsoft.Json;

namespace Domain.Mapping
{
    public class Mapping : IBaseEntity
	{
		public string Id { get; set; }
		public string Local { get; set; }
		public string Remote { get; set; }
		public string InterfaceId { get; set; }
		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
