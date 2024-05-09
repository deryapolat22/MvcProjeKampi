﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationFolder
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator() { 
    
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş bırakamazsınız");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş bırakamazsınız");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("HAkkında alanını boş bırakamazsınız");
            RuleFor(x => x.WriterSurname).MaximumLength(20).WithMessage("Lütfen en fazla yirmi karakter giriniz");
            RuleFor(x => x.WriterSurname).MaximumLength(20).WithMessage("Lütfen en fazla yirmi karakter giriniz");
            // yazar about mutlaka a harfi içersin
        }

    }
}
