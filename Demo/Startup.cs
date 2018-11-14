using ch.igorgiovannini.Translawesome.Caching;
using ch.igorgiovannini.Translawesome.Demo.Translations;
using ch.igorgiovannini.Translawesome.Providers;
using ch.igorgiovannini.Translawesome.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ch.igorgiovannini.Translawesome.Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<ITranslationProvider, CustomTranslationProvider>();
            services.AddScoped<ITranslawesomeService, TranslawesomeService>();
            services.AddScoped<ICacheService, MemoryCacheService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
