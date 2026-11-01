using EvaluatorX.Domain.Models;

using FluentValidation;

namespace EvaluatorX.Domain.Validation;

[RegisterSingleton<IValidator<UserProviderUpdateModel>>]
public partial class UserProviderUpdateModelValidator
    : AbstractValidator<UserProviderUpdateModel>
{
    public UserProviderUpdateModelValidator()
    {
        RuleFor(p => p.Provider).NotEmpty();
        RuleFor(p => p.Provider).MaximumLength(100);
        RuleFor(p => p.ProviderKey).NotEmpty();
        RuleFor(p => p.ProviderKey).MaximumLength(450);
    }
}
