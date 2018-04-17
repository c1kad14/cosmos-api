using Domain.Base;
using System;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Person : BaseEntity
	{
		public string First { get; set; }
		public string Last { get; set; }
		public string Middle { get; set; }
		public DateTime BirthDate { get; set; }
		public string Sex { get; set; }
		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}

	}
}
