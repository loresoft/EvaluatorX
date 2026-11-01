using EvaluatorX.Data;
using EvaluatorX.Data.Entities;
using EvaluatorX.Domain.Constants;

using EvaluatorX.Core.Tests;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EvaluatorX.Core.Tests.Fixtures;

public class DatabaseSeeder(IServiceProvider serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<EvaluatorContext>();

        var exists = await context.Users.AnyAsync(p => p.Id == MockClaimsPrincipal.DefaultUserId, cancellationToken);
        if (exists)
            return;

        User user = new()
        {
            Id = MockClaimsPrincipal.DefaultUserId,
            Email = "default.tester@mailinator.com",
            Name = "Default Test User",
            CreatedBy = "test",
            UpdatedBy = "test",
        };
        context.Users.Add(user);

        UserOrganization userOrganization = new()
        {
            UserId = MockClaimsPrincipal.DefaultUserId,
            OrganizationId = Organizations.Testing,
            IsOwner = true,
            CreatedBy = "test",
            UpdatedBy = "test",
        };
        context.UserOrganizations.Add(userOrganization);

        await context.SaveChangesAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
