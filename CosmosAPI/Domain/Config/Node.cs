using Domain.Base;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Config
{
    public class Node : BaseConfigEntity
	{
		public string ParentId { get; set; }
		public List<Attribute> Attributes { get; set; }
		public string InterfaceId { get; set; }
		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
