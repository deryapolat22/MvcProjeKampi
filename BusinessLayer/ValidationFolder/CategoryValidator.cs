using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationFolder
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adını boş bırakamazsınız");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı adını boş bırakamazsınız");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az üç karakter giriniz");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen en fazla yirmi karakter giriniz");

        }
    }
}
