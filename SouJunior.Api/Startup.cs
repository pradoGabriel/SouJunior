using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SouJunior.Domain.Entities;
using SouJunior.Infra.Data.Context;
using SouJunior.Infra.Helpers;
using SouJunior.Infra.Interfaces;
using SouJunior.Infra.Repository;
using SouJunior.Service.Services;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;
using System.Reflection;
using System.Text;

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
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddControllers();
            var key = Encoding.ASCII.GetBytes(AuthenticationHelper.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

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

                // Autentica��o JWT
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Description = "Insert a valid JWT token"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // Configurando injeção de dependencias 
            //Repositórios
            services.AddScoped<IBaseRepository<UsuarioEntity>, BaseRepository<UsuarioEntity>>();
            services.AddScoped<IBaseRepository<PropostaEntity>, BaseRepository<PropostaEntity>>();
            services.AddScoped<IRamoAtuacaoRepository, RamoAtuacaoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEmpresaJrRepository, EmpresaJrRepository>();
            services.AddScoped<IPropostaRepository, PropostaRepository>();
            services.AddScoped<IEmpreendedorRepository, EmpreendedorRepository>();

            // Services
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IBaseService<UsuarioEntity>, BaseService<UsuarioEntity>>();
            services.AddScoped<IBaseService<PropostaEntity>, BaseService<PropostaEntity>>();

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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
