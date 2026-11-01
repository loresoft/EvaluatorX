using Arbiter.Health;

using EvaluatorX.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EvaluatorX.Health;

public static class HealthRegistration
{
    [RegisterServices]
    public static void Register(IServiceCollection services)
    {
        services.AddHealthServices();

        var health = services.AddHealthChecks();

        // add EF database health check
        health.AddDbContextCheck<EvaluatorContext>(
            name: "Database Connection",
            tags: ["Database"],
            customTestQuery: (context, token) => context.Organizations.AnyAsync(token)
        );
    }
}
