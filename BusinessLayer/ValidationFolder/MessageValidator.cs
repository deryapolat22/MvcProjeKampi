using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationFolder
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator() 
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı alanını boş bırakamazsınız");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanını boş bırakamazsınız");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj alanını boş bırakamazsınız");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az üç karakter giriniz");
            //girilen mail geçerli bir mail adresi mi kontorlü yapılsın
        }

    }
}
