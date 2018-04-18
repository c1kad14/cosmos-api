using System.ComponentModel.DataAnnotations;
using Domain.Base;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Booking : BaseEntity
	{
		[Required(ErrorMessage = "Inmate is a required field")]
		public Inmate Inmate { get; set; }
		[Required(ErrorMessage = "BookingAgency is a required field")]
		public string BookingAgency { get; set; }

		[Required(ErrorMessage = "BookingType is a required field")]
		public string BookingType { get; set; }
		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
