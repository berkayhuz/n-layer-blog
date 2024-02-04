using FluentValidation;
using HuzlabBlog.Entities.Entities;

namespace HuzlabBlog.Service.FluentValidations
{
	public class UserValidator : AbstractValidator<AppUser>
	{
		public UserValidator()
		{
			RuleFor(x => x.FirstName)
			 .NotEmpty()
			 .MinimumLength(3)
			 .MaximumLength(50)
			 .WithName("İsim");

			RuleFor(x => x.LastName)
			 .NotEmpty()
			 .MinimumLength(3)
			 .MaximumLength(50)
			 .WithName("Soyisim");

            RuleFor(x => x.PhoneNumber)
             .NotEmpty()
             .MinimumLength(11)
             .MaximumLength(20)
             .WithName("Telefon numarası");
            
            RuleFor(x => x.Biography)
                 .NotEmpty()
                 .MinimumLength(11)
                 .MaximumLength(200)
                 .WithName("Biyografi");

            RuleFor(x => x.EmailVerificationCode)
                 .MinimumLength(4)
                 .MaximumLength(6)
                 .WithName("Email Doğrulama Kodu");
        }
	}
}
