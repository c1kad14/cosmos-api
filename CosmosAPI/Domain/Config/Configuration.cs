using Domain.Base;
using Newtonsoft.Json;

namespace Domain.Config
{
    public class Configuration : BaseConfigEntity
    {
		public string Value { get; set; }
		public string InterfaceId { get; set; }
		public string Description { get; set; }
		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
