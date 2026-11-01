using EvaluatorX.Domain.Models;

using FluentValidation;

namespace EvaluatorX.Domain.Validation;

[RegisterSingleton<IValidator<UserOrganizationUpdateModel>>]
public partial class UserOrganizationUpdateModelValidator
    : AbstractValidator<UserOrganizationUpdateModel>
{
    public UserOrganizationUpdateModelValidator()
    {
    }
}
