using System.Text.Json.Serialization;

using Arbiter.CommandQuery.Models;
using Arbiter.Mediation;

namespace EvaluatorX.Domain.Commands;

[MessagePackObject(true)]
public record InviteCleanupCommand : IRequest<CompleteModel>
{
    [JsonConstructor]
    [SerializationConstructor]
    public InviteCleanupCommand()
    {
    }
}
