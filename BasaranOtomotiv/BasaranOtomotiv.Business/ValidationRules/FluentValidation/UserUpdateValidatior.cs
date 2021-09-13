using BasaranOtomotiv.Entities.Concerete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Business.ValidationRules.FluentValidation
{
    public class UserUpdateValidatior:AbstractValidator<User>
    {
        public UserUpdateValidatior()
        {
            RuleFor(user => user.UserName).NotEmpty().WithMessage("İsim Boş Geçilemez");
            RuleFor(user => user.UserName).MinimumLength(2).WithMessage("İsim 2 Karakterden Uzun Olmalı");
            RuleFor(user => user.UserName).MaximumLength(20).WithMessage("İsim En Fazla 20 Karakter Olabilir");

            RuleFor(user => user.UserSurname).NotEmpty().WithMessage("Soyadı Boş Geçilemez");
            RuleFor(user => user.UserSurname).MinimumLength(2).WithMessage("Soyadı 2 Karakterden Uzun Olmalı");
            RuleFor(user => user.UserSurname).MaximumLength(20).WithMessage("Soyadı En Fazla 20 Karakter Olabilir");

            RuleFor(user => user.UserPassword).NotEmpty().WithMessage("Parola Boş Geçilemez");
            RuleFor(user => user.UserPassword).MinimumLength(2).WithMessage("Parola 2 Karakterden Uzun Olmalı");
            RuleFor(user => user.UserPassword).MaximumLength(30).WithMessage("Parola En Fazla 30 Karakter Olabilir");
        }
    }
}
