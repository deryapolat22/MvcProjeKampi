using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationFolder
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresi alanını boş bırakamazsınız.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanını boş bırakamazsınız.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanını boş bırakamazsınız.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj alanını boş bırakamazsınız.");
        }
    }
}
