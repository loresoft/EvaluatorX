using Arbiter.CommandQuery.EntityFramework;
using Arbiter.Communication;

using EvaluatorX.Templates;

using Microsoft.Extensions.DependencyInjection;

namespace EvaluatorX;

public static class ServiceRegistration
{
    [RegisterServices]
    public static void Register(IServiceCollection services)
    {
        services
            .AddQueryPipeline();

        services
            .AddSmtpEmailDeliver()
            .AddTemplateResourceResolver(TemplateNames.TemplateAssembly, TemplateNames.TemplateResourceFormat);
    }
}
