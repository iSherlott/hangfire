using Highfire.Services;

namespace Highfire.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static void AddIoc(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            #region Repositories
            #endregion

            #region Handlers
            #endregion

            #region Services
            services.AddHangfireServices();
            services.AddHttpClient();

            services.AddSingleton<MessageService>();
            services.AddSingleton<Consumer>();
            #endregion

            #region Dictionary
            #endregion

            #region Helper
            #endregion

        }

    }
}
