using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrdersAPI.Data;
using Microsoft.EntityFrameworkCore;
using OrdersAPI.Repositories;
using OrdersAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Server.IISIntegration;

namespace OrdersAPI
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

            services.AddResponseCompression();

            services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            }));
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
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            app.ApplicationServices.CreateScope().ServiceProvider.GetService<DataContext>().Database.EnsureCreated();
        }
    }
}
