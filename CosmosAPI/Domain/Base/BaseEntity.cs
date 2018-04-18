using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;
using Newtonsoft.Json;

namespace Domain.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

	    public bool Validate(ICollection<ValidationResult> results)
	    {
		    var ctx = new ValidationContext(this, null, null);
		    return Validator.TryValidateObject(this, ctx, results, true);
		}
    }
}
