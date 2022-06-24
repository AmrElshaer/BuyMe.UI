using BuyMe.Infrastructure.BackgroundJobs;
using Quartz;
using Serilog;

namespace ByMe.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
        {
            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();

                // Create a "key" for the job
                var jobKey = new JobKey($"{nameof(MonitorTenantJob)}");

                // Register the job with the DI container
                q.AddJob<MonitorTenantJob>(opts => opts.WithIdentity(jobKey));

                // Create a trigger for the job
                q.AddTrigger(opts => opts
                   .ForJob(jobKey) // link to the HelloWorldJob
                   .WithIdentity($"{nameof(MonitorTenantJob)}-trigger") // give the trigger a unique name
                   .WithCronSchedule("0/10 * * * * ?")); // run every 5 seconds

            });
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        }).UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext())
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
