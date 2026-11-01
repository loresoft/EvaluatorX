using Arbiter.CommandQuery.Extensions;
using Arbiter.CommandQuery.Handlers;
using Arbiter.Mapping;

using EvaluatorX.Data;
using EvaluatorX.Data.Entities;
using EvaluatorX.Domain.Models;
using EvaluatorX.Domain.Queries;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EvaluatorX.Domain.Handlers;

[RegisterTransient]
public class UserOrganizationQueryHandler : RequestHandlerBase<UserOrganizationQuery, UserOrganizationReadModel>
{
    private readonly EvaluatorContext _context;
    private readonly IMapper _mapper;

    public UserOrganizationQueryHandler(ILoggerFactory loggerFactory, EvaluatorContext context, IMapper mapper) : base(loggerFactory)
    {
        _context = context;
        _mapper = mapper;
    }

    protected override async ValueTask<UserOrganizationReadModel?> Process(UserOrganizationQuery request, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation(
            "Querying UserOrganization with UserId {UserId} and OrganizationId {OrganizationId}",
            request.UserId, request.OrganizationId);

        return await _context.UserOrganizations
            .AsNoTracking()
            .Where(x => x.UserId == request.UserId && x.OrganizationId == request.OrganizationId)
            .ProjectTo<UserOrganization, UserOrganizationReadModel>(_mapper)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
