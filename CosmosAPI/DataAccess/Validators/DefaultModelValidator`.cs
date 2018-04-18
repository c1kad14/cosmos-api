using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Interfaces;

namespace DataAccess.Validators
{
    public class DefaultModelValidator<TEntity> where TEntity : class, IBaseEntity, new()
	{
	    public List<ValidationResult> Validate(TEntity entity)
	    {
		    var errors = new List<ValidationResult>();
		    entity.Validate(errors);
		    return errors;
	    }
	}
}
