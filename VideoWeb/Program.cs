using VideoWeb.Components;
using Microsoft.EntityFrameworkCore;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContextFactory<StorageBroker>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("StorageBroker") ?? throw new InvalidOperationException(
        "Server=(localdb)\\MSSQLLocalDB;Database=VideoDB;Trusted_Connection=True;MultipleActiveResultSets=true")));

        builder.Services.AddQuickGridEntityFrameworkAdapter();

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);

            app.UseHsts();
            app.UseMigrationsEndPoint();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}