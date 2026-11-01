using EvaluatorX.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EvaluatorX.Migrations.PostgreSql;

public class DesignTimeContextFactory : IDesignTimeDbContextFactory<EvaluatorContext>
{
    public EvaluatorContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable("EVALUATORX_POSTGRESQL_CONNECTION")
            ?? "Host=localhost;Database=EvaluatorX;Username=postgres;Password=postgres";

        var options = new DbContextOptionsBuilder<EvaluatorContext>()
            .UseEstimatorProvider(DatabaseProvider.PostgreSQL, connectionString)
            .Options;

        return new EvaluatorContext(options);
    }
}
