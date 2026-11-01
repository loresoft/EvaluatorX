using EvaluatorX.Domain.Models;

using FluentValidation;

namespace EvaluatorX.Domain.Validation;

[RegisterSingleton<IValidator<UserLoginCreateModel>>]
public partial class UserLoginCreateModelValidator
    : AbstractValidator<UserLoginCreateModel>
{
    public UserLoginCreateModelValidator()
    {
        RuleFor(p => p.UserId).NotEmpty();
        RuleFor(p => p.IpAddress).MaximumLength(50);
    }
}
