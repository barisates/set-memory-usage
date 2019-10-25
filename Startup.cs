using set_memory_usage.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace set_memory_usage
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<IMemoryService, MemoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Development
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Production
            else
            {
                // ExceptionHandler Middleware
                app.UseExceptionHandler(a => a.Run(async context =>
                {
                    var feature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = feature.Error;

                    var error = new
                    {
                        Data = (exception.Data != null ? exception.Data : null),
                        HelpLink = (exception.HelpLink != null ? exception.HelpLink : null),
                        HResult = exception.HResult.ToString(),
                        InnerException = (exception.InnerException != null ? exception.InnerException : null),
                        Message = (exception.Message != null ? exception.Message : null),
                        Source = (exception.Source != null ? exception.Source : null),
                        StackTrace = (exception.StackTrace != null ? exception.StackTrace : null),
                        TargetSite = (exception.TargetSite != null ? exception.TargetSite : null)
                    };

                    string result = JsonConvert.SerializeObject(new { error });

                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(result);
                }));

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
