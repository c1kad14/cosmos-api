using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Domain.Interfaces
{
    public interface IBaseEntity
	{
		[JsonProperty(PropertyName = "id")]
		string Id { get; set; }

		bool Validate(ICollection<ValidationResult> results);
	}
}
