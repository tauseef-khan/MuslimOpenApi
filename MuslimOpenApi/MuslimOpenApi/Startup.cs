using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MuslimOpenApi.Data;
using Npgsql;
using System;

namespace MuslimOpenApi
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
            services.AddControllers();

            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = Environment.GetEnvironmentVariable("HOST"),
                Port = 5432,
                Username = Environment.GetEnvironmentVariable("USERNAME"),
                Password = Environment.GetEnvironmentVariable("PASSWORD"),
                Database = Environment.GetEnvironmentVariable("DATABASE"),
                Pooling = true,
                TrustServerCertificate = true,
                SslMode = SslMode.Require
            };

            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.ToString()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
