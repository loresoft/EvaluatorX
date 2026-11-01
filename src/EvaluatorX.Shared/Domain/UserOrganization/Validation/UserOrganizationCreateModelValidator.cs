using EvaluatorX.Domain.Models;

using FluentValidation;

namespace EvaluatorX.Domain.Validation;

[RegisterSingleton<IValidator<UserOrganizationCreateModel>>]
public partial class UserOrganizationCreateModelValidator
    : AbstractValidator<UserOrganizationCreateModel>
{
    public UserOrganizationCreateModelValidator()
    {
    }
}
