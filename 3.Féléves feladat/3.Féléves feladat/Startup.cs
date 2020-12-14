using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Logic;
using Repository;
using Models;


namespace _3.Féléves_feladat
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepo<User>, UserRepo>();
            services.AddTransient<UserLogic,UserLogic>();
            services.AddTransient<GameLogic, GameLogic>();
            services.AddTransient<IRepo<Game>, GameRepo>();
            services.AddTransient<AchiLogic, AchiLogic>();
            services.AddTransient<IRepo<Achievement>, AchievementRepo>();

            services.AddMvc(opt => opt.EnableEndpointRouting = false).AddRazorRuntimeCompilation();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseMvcWithDefaultRoute();
            app.UseRouting();

            app.UseStaticFiles();

        }
    }
}
