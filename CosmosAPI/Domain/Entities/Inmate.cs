using Domain.Base;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Inmate : BaseEntity
	{
		public string Agency { get; set; }
		public Person Person { get; set; }
		public string AssignedHousing { get; set; }
		public string CurrentBookingId { get; set; }
		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
