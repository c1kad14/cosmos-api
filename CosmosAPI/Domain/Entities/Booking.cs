using Domain.Base;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Booking : BaseEntity
	{
		public Inmate Inmate { get; set; }
		public string BookingAgency { get; set; }
		public string BookingType { get; set; }
		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
