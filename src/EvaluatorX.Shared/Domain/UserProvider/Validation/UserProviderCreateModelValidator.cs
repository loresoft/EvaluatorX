using EvaluatorX.Domain.Models;

using FluentValidation;

namespace EvaluatorX.Domain.Validation;

[RegisterSingleton<IValidator<UserProviderCreateModel>>]
public partial class UserProviderCreateModelValidator
    : AbstractValidator<UserProviderCreateModel>
{
    public UserProviderCreateModelValidator()
    {
        RuleFor(p => p.Provider).NotEmpty();
        RuleFor(p => p.Provider).MaximumLength(100);
        RuleFor(p => p.ProviderKey).NotEmpty();
        RuleFor(p => p.ProviderKey).MaximumLength(450);
    }
}
