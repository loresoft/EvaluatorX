using EvaluatorX.Domain.Models;

using FluentValidation;

namespace EvaluatorX.Domain.Validation;

[RegisterSingleton<IValidator<OrganizationCreateModel>>]
public partial class OrganizationCreateModelValidator
    : AbstractValidator<OrganizationCreateModel>
{
    public OrganizationCreateModelValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Name).MaximumLength(100);
        RuleFor(p => p.Description).MaximumLength(255);
    }
}
