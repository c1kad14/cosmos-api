using Domain.Base;
using Newtonsoft.Json;

namespace Domain.Config
{
    public class Interface : BaseConfigEntity
    {
		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
