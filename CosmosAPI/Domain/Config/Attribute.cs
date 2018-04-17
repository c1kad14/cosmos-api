using Domain.Base;
using Newtonsoft.Json;

namespace Domain.Config
{
    public class Attribute : BaseConfigEntity
	{
		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}

	}
}
