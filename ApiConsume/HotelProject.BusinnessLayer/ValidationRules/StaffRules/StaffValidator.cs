
using FluentValidation;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinnessLayer.ValidationRules.StaffRules
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen bu alanı doldurun.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Ad Soyad 50 karakterden kısa olmalıdır");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen bu alanı doldurun.");
            RuleFor(x => x.Title).MaximumLength(25).WithMessage("Unvan 25 karakterden kısa olmalıdır.");
            RuleFor(x => x.SocailMedia1).NotEmpty().WithMessage("Lütfen bu alanı doldurun.");
            RuleFor(x => x.SocailMedia2).NotEmpty().WithMessage("Lütfen bu alanı doldurun.");
            RuleFor(x => x.SocailMedia3).NotEmpty().WithMessage("Lütfen bu alanı doldurun.");

        }
    }
}
