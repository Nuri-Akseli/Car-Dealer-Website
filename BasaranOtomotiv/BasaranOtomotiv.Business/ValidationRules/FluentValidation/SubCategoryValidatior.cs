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
    public class SubCategoryValidatior:AbstractValidator<SubCategory>
    {
        ISubCategoryService _subCategoryService;
        public SubCategoryValidatior(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;


            RuleFor(subCategory => subCategory.SubCategoryName).NotEmpty().WithMessage("Alt Kategori Adı Boş Geçilemez");
            RuleFor(subCategory => subCategory.SubCategoryName).MinimumLength(2).WithMessage("Alt Kategori Adı 2 Karakterden Uzun Olmalı");
            RuleFor(subCategory => subCategory.SubCategoryName).MaximumLength(20).WithMessage("Alt Kategori Adı 20 Karakterden Uzun Olamaz");
            RuleFor(subCategory => subCategory.SubCategoryName).Must(Unique).WithMessage("Alt Kategori Zaten Sistemde Mevcut");
        }

        private bool Unique(string arg)
        {
            var result = _subCategoryService.GetBySubcategoryName(arg);
            return result == null
                ? true
                : false;
        }
    }
}
