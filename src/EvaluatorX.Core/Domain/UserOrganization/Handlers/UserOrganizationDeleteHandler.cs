using Arbiter.CommandQuery.Handlers;
using Arbiter.CommandQuery.Models;

using EvaluatorX.Data;
using EvaluatorX.Domain.Commands;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EvaluatorX.Domain.Handlers;

[RegisterTransient]
public class UserOrganizationDeleteHandler : RequestHandlerBase<UserOrganizationDeleteCommand, CompleteModel>
{
    private readonly EvaluatorContext _context;

    public UserOrganizationDeleteHandler(ILoggerFactory loggerFactory, EvaluatorContext context) : base(loggerFactory)
    {
        _context = context;
    }

    protected override async ValueTask<CompleteModel?> Process(UserOrganizationDeleteCommand request, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation(
            "Deleting UserOrganization with UserId {UserId} and OrganizationId {OrganizationId}",
            request.UserId, request.OrganizationId);

        var count = await _context.UserOrganizations
            .Where(x => x.UserId == request.UserId && x.OrganizationId == request.OrganizationId)
            .ExecuteDeleteAsync(cancellationToken);

        return CompleteModel.Success($"Deleted {count} UserOrganization(s)");
    }
}
