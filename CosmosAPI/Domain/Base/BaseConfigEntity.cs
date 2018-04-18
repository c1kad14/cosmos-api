using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;

namespace Domain.Base
{
    public abstract class BaseConfigEntity : IBaseEntity
    {
		public string Id { get; set; }
		public string Name { get; set; }
	    public bool Validate(ICollection<ValidationResult> results)
	    {
		    var ctx = new ValidationContext(this, null, null);
		    return Validator.TryValidateObject(this, ctx, results, true);
	    }
	}
}
