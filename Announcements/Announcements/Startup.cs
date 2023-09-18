using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Announcements
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AnnouncementsAPI", Version = "v1" });
            });
        }
    }
}
