using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SouJunior.Domain.Entities;
using SouJunior.Domain.Interfaces;
using SouJunior.Infra.Data.Context;
using SouJunior.Infra.Repository;
using SouJunior.Service.Interfaces;
using SouJunior.Service.Services;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;
using System.Reflection;

namespace SouJunior
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConnectionString = Configuration.GetSection("SqlConnectionString").Get<string>() ?? "";
            services.AddDbContext<MyContext>(
                options => options.UseSqlServer(sqlConnectionString)
            );

            // Add CORS policy
            services.AddCors(options =>
            {
                options.AddPolicy("foo",
                builder =>
                {
                    // Not a permanent solution, but just trying to isolate the problem
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddControllers();

            //services.AddAuthentication(a =>
            //{
            //    a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(j =>
            //{
            //    j.RequireHttpsMetadata = false;
            //    j.SaveToken = true;
            //    j.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(AuthenticationHelper.GetKeyBytes()),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});

            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",

                    new OpenApiInfo
                    {
                        Title = "SouJunior.Api",
                        Version = "v1",
                        Description = "APIs - SouJunior",
                        Contact = new OpenApiContact
                        {
                            Name = "SouJunior"
                        }
                    });
                c.ExampleFilters();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // Configurando injeção de dependencias 
            services.AddScoped<IBaseRepository<UsuarioEntity>, BaseRepository<UsuarioEntity>>();
            services.AddScoped<IBaseService<UsuarioEntity>, BaseService<UsuarioEntity>>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IAuthService, AuthService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("TodasUrlsLiberadas");

            //app.UseAuthentication();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SouJunior API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            // Use the CORS policy
            app.UseCors("foo"); // second
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
