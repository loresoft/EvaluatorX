using Arbiter.CommandQuery;

using Microsoft.Extensions.DependencyInjection;

namespace EvaluatorX.Services;

internal static class ServiceRegistration
{
    [RegisterServices]
    public static void Register(IServiceCollection services)
    {
        services.AddCommandQuery();
        services.AddCommandValidation();

        services.AddHybridCache();
        services.AddEntityHybridCacheExpireBehavior();
    }
}
