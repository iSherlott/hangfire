using Hangfire;

namespace Highfire.Middleware
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHangfireDashboard("/hangfire", new DashboardOptions
                {
                    Authorization = new[] { new AllowAllAuthorizationFilter() }
                });
            });

            return app;
        }
    }
}
