using Arbiter.CommandQuery.EntityFramework.Handlers;
using Arbiter.CommandQuery.Models;
using Arbiter.Mapping;

using EvaluatorX.Data;
using EvaluatorX.Data.Queries;
using EvaluatorX.Domain.Commands;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EvaluatorX.Domain.Handlers;

[RegisterTransient]
public class InviteCleanupHandler : DataContextHandlerBase<EvaluatorContext, InviteCleanupCommand, CompleteModel>
{
    public InviteCleanupHandler(
        ILoggerFactory loggerFactory,
        EvaluatorContext dataContext,
        IMapper mapper)
        : base(loggerFactory, dataContext, mapper)
    {
    }

    protected override async ValueTask<CompleteModel?> Process(InviteCleanupCommand request, CancellationToken cancellationToken)
    {
        // remove expired invites with a grace period of 30 days
        var expiredInvites = await DataContext.Invites
            .RemoveExpiredInvites(cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        Logger.LogInformation("Removed {Count} expired invites", expiredInvites);

        return CompleteModel.Success();
    }
}
