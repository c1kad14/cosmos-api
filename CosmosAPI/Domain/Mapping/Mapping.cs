using Domain.Base;
using Newtonsoft.Json;

namespace Domain.Mapping
{
    public class Mapping : BaseEntity
	{
		public string Local { get; set; }
		public string Remote { get; set; }
		public string InterfaceId { get; set; }
		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
