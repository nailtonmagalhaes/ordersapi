using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrdersAPI.Data;
using Microsoft.EntityFrameworkCore;
using OrdersAPI.Repositories;
using OrdersAPI.Repositories.Interfaces;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.Swagger;
using System.IO;

namespace OrdersAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public object PlatformServices { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy("All", builder =>
                 {
                     builder.AllowAnyOrigin();
                     builder.AllowAnyMethod();
                     builder.AllowAnyHeader();
                 });
            });
            // services.AddCors(options =>
            // {
            //     options.AddPolicy(
            //       "CorsPolicy",
            //       builder => builder.WithOrigins("http://localhost:4200")
            //                         .AllowAnyMethod()
            //                         .AllowAnyHeader()
            //                         .AllowCredentials());
            // });
            // services.AddAuthentication(IISDefaults.AuthenticationScheme);

            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("DbOrdersControl"));
            //services.AddScoped<DataContext, DataContext>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IPostalCodeRangeRepository, PostalCodeRangeRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1",
            //        new Microsoft.OpenApi.Models.OpenApiInfo
            //        {
            //            Title = "Conversor de Temperaturas",
            //            Version = "v1",
            //            Description = "Exemplo de API REST criada com o ASP.NET Core",
            //            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            //            {
            //                Name = "Renato Groffe",
            //                Url = new System.Uri("https://github.com/renatogroffe")
            //            }
            //        });

            //    string caminhoAplicacao =
            //        PlatformServices.Default.Application.ApplicationBasePath;
            //    string nomeAplicacao =
            //        PlatformServices.Default.Application.ApplicationName;
            //    string caminhoXmlDoc =
            //        Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

            //    c.IncludeXmlComments(caminhoXmlDoc);
            //});

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Place Info Service API",
                    Version = "v2",
                    Description = "Sample service for Learner",
                });
            });

            services.AddResponseCompression();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("All");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "PlaceInfo Services"));

            app.ApplicationServices.CreateScope().ServiceProvider.GetService<DataContext>().Database.EnsureCreated();
        }
    }
}
