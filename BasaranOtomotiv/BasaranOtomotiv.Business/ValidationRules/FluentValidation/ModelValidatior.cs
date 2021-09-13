using BasaranOtomotiv.Entities.Concerete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Business.ValidationRules.FluentValidation
{
    public class ModelValidatior:AbstractValidator<Model>
    {
        public ModelValidatior()
        {
            RuleFor(model => model.ModelName).NotEmpty().WithMessage("Model Adı Boş Geçilemez");
            RuleFor(model => model.ModelName).MinimumLength(2).WithMessage("Model Adı 2 Karakterden Uzun Olmalı");
            RuleFor(model => model.ModelName).MaximumLength(20).WithMessage("Model Adı 20 Karakterden Uzun Olamaz");
        }
    }
}
