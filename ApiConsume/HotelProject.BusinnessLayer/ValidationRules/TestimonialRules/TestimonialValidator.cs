using FluentValidation;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinnessLayer.ValidationRules.TestimonialRules
{
    public class TestimonialValidator : AbstractValidator<Testimonial>
    {
        public TestimonialValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen bu alanı doldurun.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Ad soyad 50 karakterden kısa olmalıdır.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen bu alanı doldurun.");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Ünvan 50 karakterden kısa olmalıdır");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen bu alanı doldurun");
            RuleFor(x => x.Description).MaximumLength(150).WithMessage("Açıklama 150 karakterden kısa olmalıdır.");
        }
    }
}
