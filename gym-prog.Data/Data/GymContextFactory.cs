using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace gym_prog.Data.Data
{
    public class GymContextFactory : IDesignTimeDbContextFactory<GymContext>
    {
        public GymContext CreateDbContext(string[] args)
        {
            var serverProjectPath = Path.GetFullPath(Path.Combine(
                Directory.GetCurrentDirectory(),
                "..",
                "gym-prog.Server"));

            var configuration = new ConfigurationBuilder()
                .SetBasePath(serverProjectPath)
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<GymContext>();
            var connectionString = configuration.GetConnectionString("GymContext");

            builder.UseSqlServer(connectionString);

            return new GymContext(builder.Options);
        }
    }
}
