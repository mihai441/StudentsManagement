using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentsManagement.Domain.Services;
using StudentsManagement.Core.Shared;
using StudentsManagement.Persistence;
using StudentsManagement.Persistence.EF;
using StudentManagement.Authentication;

namespace WebStudentsManagement
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

            services.AddTransient<IEmailSender, EmailSender>();

            var authService = new AuthenticationServices(null, null);
            authService.InitializeContext(services, Configuration);
            services.AddScoped<IAuthentication, AuthenticationServices>();           
            

            //Add persistence service
            services.AddScoped<IPersistenceContext, PersistenceContext>();
            var dataService = services.BuildServiceProvider().GetService<IPersistenceContext>();
            dataService.InitializeContext(services, Configuration);
            
            //Add Business Layer 
            services.AddScoped<IBusinessLayer, BusinessLogic>(s => new BusinessLogic(dataService));
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
