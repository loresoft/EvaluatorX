using Arbiter.CommandQuery.Handlers;
using Arbiter.CommandQuery.Models;

using EvaluatorX.Data;
using EvaluatorX.Domain.Commands;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EvaluatorX.Domain.Handlers;

[RegisterTransient]
public class UserOrganizationOwnerHandler : RequestHandlerBase<UserOrganizationOwnerCommand, CompleteModel>
{
    private readonly EvaluatorContext _context;

    public UserOrganizationOwnerHandler(ILoggerFactory loggerFactory, EvaluatorContext context) : base(loggerFactory)
    {
        _context = context;
    }

    protected override async ValueTask<CompleteModel?> Process(UserOrganizationOwnerCommand request, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation(
            "Updating UserOrganization with UserId {UserId} and OrganizationId {OrganizationId} to IsOwner {IsOwner}",
            request.UserId, request.OrganizationId, request.IsOwner);

        var userOrganization = await _context.UserOrganizations
            .FirstOrDefaultAsync(x => x.UserId == request.UserId && x.OrganizationId == request.OrganizationId, cancellationToken);

        if (userOrganization == null)
        {
            userOrganization = new Data.Entities.UserOrganization
            {
                UserId = request.UserId,
                OrganizationId = request.OrganizationId,
                Created = DateTimeOffset.UtcNow,
                CreatedBy = request.ActivatedBy,
            };
            await _context.UserOrganizations.AddAsync(userOrganization, cancellationToken);
        }

        userOrganization.IsOwner = request.IsOwner;
        userOrganization.Updated = DateTimeOffset.UtcNow;
        userOrganization.UpdatedBy = request.ActivatedBy;

        await _context.SaveChangesAsync(cancellationToken);

        return CompleteModel.Success("UserOrganization updated successfully");
    }
}
