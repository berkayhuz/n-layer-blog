using FluentValidation;
using HuzlabBlog.Entities.Entities;

namespace HuzlabBlog.Service.FluentValidations
{
    public class SettingValidator : AbstractValidator<Setting>
    {
        public SettingValidator()
        {
            RuleFor(x => x.AppDesc)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithName("Uygulama Açıklaması");

            RuleFor(x => x.AppKeyword)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithName("Keyword 1, Keyword 2, Keyword 3");
        }
    }
}
