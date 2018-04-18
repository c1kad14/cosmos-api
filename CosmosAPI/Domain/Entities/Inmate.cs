using System.ComponentModel.DataAnnotations;
using Domain.Base;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Inmate : BaseEntity
	{

		[Required(ErrorMessage = "Agency is a required field")]
		public string Agency { get; set; }
		[Required(ErrorMessage = "Person is a required field")]
		public Person Person { get; set; }
		public string AssignedHousing { get; set; }
		public string CurrentBookingId { get; set; }
		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
