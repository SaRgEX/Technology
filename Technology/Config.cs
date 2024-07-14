using Technology.Controllers;
using Technology.Middleware;
using Technology.Service.Randoms;

namespace Technology
{
    public static class Config
    {
        public static void AddConfig(IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<RandomClient>(
                x => new RandomClient(configuration["RandomApi"]));
            services.AddTransient<ICollection<string>>(
                x => configuration.GetSection("Settings:BlackList").Get<HashSet<string>>() ?? new());
            RequestLimit.MaxCount = configuration.GetValue<int>("Settings:ParallelLimit");
        }
    }
}
