#pragma warning disable IDE0130 // Namespace does not match folder structure

using Arbiter.CommandQuery.EntityFramework;

using Microsoft.Extensions.DependencyInjection;

using Context = EvaluatorX.Data;
using Entities = EvaluatorX.Data.Entities;

namespace EvaluatorX.Domain;

public static class OrganizationServiceRegistration
{
    [RegisterServices]
    public static void Register(IServiceCollection services)
    {
        services.AddEntityQueries<Context.EvaluatorContext, Entities.Organization, long, Models.OrganizationReadModel>();
        services.AddEntityCommands<Context.EvaluatorContext, Entities.Organization, long, Models.OrganizationReadModel, Models.OrganizationCreateModel, Models.OrganizationUpdateModel>();
    }
}
