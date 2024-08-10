using Microsoft.EntityFrameworkCore;
using VideoWeb.Models;

public class StorageBroker : DbContext
{
    private readonly IConfiguration configuration;

    public StorageBroker(IConfiguration configuration)
    {
        this.configuration = configuration;
        Database.Migrate();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=VideoDb;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
    public DbSet<VideoMetadata> VideoMetadata { get; set; }
}
