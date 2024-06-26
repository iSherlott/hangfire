using Hangfire;
using Hangfire.MemoryStorage;

namespace Highfire.Configuration
{
    public static class Hangfire
    {
        public static void AddHangfireServices(this IServiceCollection services)
        {
            services.AddHangfire(config =>
            {
                config.UseMemoryStorage();
            });

            services.AddHangfireServer(options =>
            {
                options.WorkerCount = 1; 
            });
        }
    }
}
