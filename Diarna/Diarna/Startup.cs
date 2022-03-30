using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Diarna.Data;
using Diarna.Services.Interfaces;
using Diarna.Services.Reposatories;
using System.Reflection;
using System.IO;

namespace Diarna
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
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DiarnaContext>(x => x.UseSqlServer(connectionString));
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); 
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Diarna", Version = "v1" });
            //});
            services.AddScoped<IItemTypeRepo,ItemTypeRepo>();
            services.AddScoped<IItemRepo, ItemRepo>();
            services.AddScoped<IRentedUnitRepo, RentedUnitRepo>();
            services.AddScoped<IUpdateUnitDataRepo, UpdateUnitDataRepo>();
            services.AddScoped<IRentExpensesRepo, RentExpensesRepo>(); 
            services.AddScoped<IVillageRepo,VillageRepo>();
            services.AddScoped<IUnitRepo,UnitRepo>();
            services.AddScoped<IBuildingRepo,BuildingRepo>();
            services.AddScoped<IReservationRepo,ReservationRepo>();
            services.AddScoped<IReservationDateRepo,ReservationDateRepo>();
            services.AddScoped<IRentUserRepo,RentUserRepo>();
            services.AddScoped<IRentShareRepo, RentShareRepo>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(
                    options =>
                    {

                        //API name, API information
                        options.SwaggerDoc("Diarna", new Microsoft.OpenApi.Models.OpenApiInfo()
                        {
                            Title = "Diarna",
                            Version = "v1",
                            Description = "this is description to...",
                            Contact = new OpenApiContact
                            {
                                Name = "Eng.....Diyarna", //any name
                                Email = "https://github.com/dev-mahmoud-alsaied/Dyarna/",// any Email
                                Url = new Uri("https://github.com/dev-mahmoud-alsaied/Dyarna/")
                            },
                            License = new OpenApiLicense
                            {
                                Name = "Licence",
                                Url = new Uri("https://github.com/dev-mahmoud-alsaied/Dyarna/")
                            }

                        });

                        var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                        var commentFilePath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
                        options.IncludeXmlComments(commentFilePath);
                    }

                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Diarna v1"));
                app.UseSwaggerUI(
                 options => {
                     options.SwaggerEndpoint("/swagger/Diarna/swagger.json", "Diarna v1");
                     options.RoutePrefix = "";
                 }
               );
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id:int?}");
            });
        }
    }
}
