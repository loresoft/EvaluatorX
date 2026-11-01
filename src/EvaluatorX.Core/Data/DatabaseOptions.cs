namespace EvaluatorX.Data;

public class DatabaseOptions
{
    public const string SectionName = "Database";

    public const string DefaultConnectionString = "Data Source=/home/app/data/EvaluatorX.db";


    public string? Provider { get; set; }

    public string? ConnectionString { get; set; }

    public bool MigrateOnStartup { get; set; } = true;
}
