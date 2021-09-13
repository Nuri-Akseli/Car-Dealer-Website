using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Core.Utilities.Validation.FluentValidation
{
    public interface IValidate
    {
        ValidationResult IsValid(object entity);
    }
}
