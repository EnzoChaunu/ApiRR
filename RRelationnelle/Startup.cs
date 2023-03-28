using Business.Interfaces;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RRelationnelle.Repos;
using RRelationnelle.Service;
using System.Linq;
using System.Text;

namespace RRelationnelle
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RRelationnelle", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
                

            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
            services.AddScoped<IJwTAuthentificationService, JwtAuthentificationServices>();
            services.AddScoped<IJwTAuthRepository, JwTAuthRepository>();



            services.AddDbContext<RrelationnelApiContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ApiRessourceConnection"), b => b.MigrationsAssembly("Commun"))
                );

            services.AddMemoryCache();

            services.AddScoped<RRelationnelle.Service.RessourceService>();
            services.AddScoped<RRelationnelle.CategoryRepository>();
            services.AddScoped<IRessourceRepo, RessourcesRepo>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IService<CategoryDto>, CategoryService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IService<RessourceDto>, RessourceService>();
            services.AddScoped<IApiGouv, ApiRGouv>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IRoleService, RolesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RRelationnelle v1"));
            }

            app.UseHttpsRedirection();
            app.UseDeveloperExceptionPage();
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
