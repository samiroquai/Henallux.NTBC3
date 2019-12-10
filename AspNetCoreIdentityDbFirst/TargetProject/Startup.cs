using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TargetProject
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
            services.AddDbContext<FakeAppDemoContext>(options =>
                  options.UseSqlServer(
                      "Server=localhost\\SQLEXPRESS;Initial Catalog=FakeAppDemo;Integrated Security=true"));
            services.AddTransient<Func<FakeAppDemoContext>>((provider) =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<FakeAppDemoContext>();
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Initial Catalog=FakeAppDemo;Integrated Security=true");
                return () => new FakeAppDemoContext(optionsBuilder.Options);
            });

            services.AddIdentity<MyUserClass, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<FakeAppDemoContext>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
