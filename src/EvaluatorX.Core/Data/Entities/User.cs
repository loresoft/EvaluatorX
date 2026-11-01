using Arbiter.CommandQuery.Definitions;

namespace EvaluatorX.Data.Entities;

public class User : IHaveIdentifier<long>, ITrackCreated, ITrackUpdated
{
    public long Id { get; set; }

    public string? Email { get; set; }

    public string? Name { get; set; }

    public bool IsAdministrator { get; set; }

    public bool IsDisabled { get; set; }


    public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;

    public string? CreatedBy { get; set; }

    public DateTimeOffset Updated { get; set; } = DateTimeOffset.UtcNow;

    public string? UpdatedBy { get; set; }


    public virtual ICollection<UserProvider> UserProviders { get; set; } = new HashSet<UserProvider>();

    public virtual ICollection<UserOrganization> UserOrganizations { get; set; } = new HashSet<UserOrganization>();

    public virtual ICollection<UserLogin> UserLogins { get; set; } = new HashSet<UserLogin>();
}
