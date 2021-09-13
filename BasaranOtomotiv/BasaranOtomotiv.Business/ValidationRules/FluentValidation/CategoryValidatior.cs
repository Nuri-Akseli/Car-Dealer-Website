using BasaranOtomotiv.Business.Abstract;
using BasaranOtomotiv.Entities.Concerete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Business.ValidationRules.FluentValidation
{
    public class CategoryValidatior:AbstractValidator<Category>
    {
        ICategoryService _categoryService;
        public CategoryValidatior(ICategoryService categoryService)
        {
            _categoryService = categoryService;


            RuleFor(category => category.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Bırakılamaz");
            RuleFor(category => category.CategoryName).MinimumLength(2).WithMessage("Kategori Adı 2 Karakterden Uzun Olmalı") ;
            RuleFor(category => category.CategoryName).MaximumLength(20).WithMessage("Kategori Adı 20 Karakterden Fazla Olamaz");
            RuleFor(Category => Category.CategoryName).Must(Unique).WithMessage("Kategori Adı Zaten Sistemde Var");
        }

        private bool Unique(string arg)
        {
            var result = _categoryService.GetByCategoryName(arg);
            return result == null
                ? true
                : false;
        }
    }
}
