using BasaranOtomotiv.Entities.Concerete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Business.ValidationRules.FluentValidation
{
    public class EngineValidatior:AbstractValidator<Engine>
    {
        public EngineValidatior()
        {
            RuleFor(engine => engine.EngineName).NotEmpty().WithMessage("Motor Adı Boş Geçilemez");
            RuleFor(engine => engine.EngineName).MinimumLength(2).WithMessage("Motor Adı 2 Karakterden Uzun Olmalı");
            RuleFor(engine => engine.EngineName).MaximumLength(20).WithMessage("Motor Adı 20 Karakterden Uzun Olamaz");
        }
    }
}
