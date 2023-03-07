using IydeParfume.Services.Abstracts;
using IydeParfume.Services.Concretes;

namespace IydeParfume.Infrastructure.Configurations
{
    public static class RegisterCustomServicesConfigurations
    {
        public static void RegisterCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFileService, FileService>();

        }
    }
}
