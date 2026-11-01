using EvaluatorX.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EvaluatorX.Migrations.Sqlite;

public class DesignTimeContextFactory : IDesignTimeDbContextFactory<EvaluatorContext>
{
    public EvaluatorContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable("EVALUATORX_SQLITE_CONNECTION")
            ?? "Data Source=EvaluatorX.db";

        var options = new DbContextOptionsBuilder<EvaluatorContext>()
            .UseEstimatorProvider(DatabaseProvider.SQLite, connectionString)
            .Options;

        return new EvaluatorContext(options);
    }
}
