using EvaluatorX.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EvaluatorX.Migrations.SqlServer;

public class DesignTimeContextFactory : IDesignTimeDbContextFactory<EvaluatorContext>
{
    public EvaluatorContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable("EVALUATORX_SQLSERVER_CONNECTION")
            ?? "Server=(localdb)\\MSSQLLocalDB;Database=EvaluatorX;Trusted_Connection=True;TrustServerCertificate=True";

        var options = new DbContextOptionsBuilder<EvaluatorContext>()
            .UseEstimatorProvider(DatabaseProvider.SqlServer, connectionString)
            .Options;

        return new EvaluatorContext(options);
    }
}
