using FluentValidation;
using HuzlabBlog.Entities.Entities;

namespace HuzlabBlog.Service.FluentValidations
{
    public class SubscribeValidator : AbstractValidator<Subscribe>
    {
        public SubscribeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(20)
                .WithName("İsim");

            RuleFor(x => x.Surname)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(20)
                .WithName("Soyisim");

            RuleFor(x => x.Email)
               .NotEmpty()
               .NotNull()
               .MinimumLength(10)
               .MaximumLength(100)
               .WithName("Email");
        }
    }
}
