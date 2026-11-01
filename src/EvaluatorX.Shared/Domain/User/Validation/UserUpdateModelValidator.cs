using EvaluatorX.Domain.Models;

using FluentValidation;

namespace EvaluatorX.Domain.Validation;

[RegisterSingleton<IValidator<UserUpdateModel>>]
public partial class UserUpdateModelValidator
    : AbstractValidator<UserUpdateModel>
{
    public UserUpdateModelValidator()
    {
        RuleFor(p => p.Email).MaximumLength(256);
        RuleFor(p => p.Name).MaximumLength(256);
    }
}
