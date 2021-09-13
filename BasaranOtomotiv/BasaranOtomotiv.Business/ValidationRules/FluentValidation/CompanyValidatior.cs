using BasaranOtomotiv.Entities.Concerete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Business.ValidationRules.FluentValidation
{
    public class CompanyValidatior:AbstractValidator<Company>
    {
        public CompanyValidatior()
        {
            RuleFor(company => company.CompanyName).NotEmpty().WithMessage("Firma Adı Boş Geçilemez");
            RuleFor(company => company.CompanyName).MaximumLength(20).WithMessage("Firma Adı 20 Karakterden Fazla Olamaz");
            RuleFor(company => company.CompanyName).MinimumLength(2).WithMessage("Firma Adı 2 Karakterden Uzun Olamaz");
        }
    }
}
