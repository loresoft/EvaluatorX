#pragma warning disable IDE0130 // Namespace does not match folder structure

using Arbiter.CommandQuery.EntityFramework;

using Microsoft.Extensions.DependencyInjection;

using Context = EvaluatorX.Data;
using Entities = EvaluatorX.Data.Entities;

namespace EvaluatorX.Domain;

public static class UserOrganizationServiceRegistration
{
    [RegisterServices]
    public static void Register(IServiceCollection services)
    {
        services.AddEntityQueries<Context.EvaluatorContext, Entities.UserOrganization, long, Models.UserOrganizationReadModel>();
        services.AddEntityCommands<Context.EvaluatorContext, Entities.UserOrganization, long, Models.UserOrganizationReadModel, Models.UserOrganizationCreateModel, Models.UserOrganizationUpdateModel>();
    }
}
