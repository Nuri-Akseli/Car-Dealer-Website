using BasaranOtomotiv.Core.Entities;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Core.Utilities.Validation.FluentValidation
{
    public class Validate:IValidate
    {
        IValidator _validator;
        public Validate(IValidator validator)
        {
            _validator = validator;
        }
        public ValidationResult IsValid(object entity)
        {
            var context = new ValidationContext<object>(entity);
            return _validator.Validate(context);
        }
    }
}
