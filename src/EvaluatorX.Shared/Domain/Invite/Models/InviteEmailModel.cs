namespace EvaluatorX.Domain.Models;

[Equatable, MessagePackObject(true)]
public partial class InviteEmailModel
{
    public required int ExpireDays { get; set; } = 30;

    public required string Link { get; set; }

    public string? ProductName { get; set; } = "EvaluatorX";

    public string? CompanyName { get; set; }
}
