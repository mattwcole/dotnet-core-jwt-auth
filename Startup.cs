using System.Threading.Tasks;
using AuthDemo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace AuthDemo
{
    public class Startup {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlite("Filename=./Users.db"));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddOpenIddict<ApplicationDbContext>()
                .AddMvcBinders()
                .EnableTokenEndpoint("/connect/token")
                .AllowPasswordFlow()
                .AllowRefreshTokenFlow()
                .DisableHttpsRequirement()
                .AddEphemeralSigningKey()
                .UseJsonWebTokens();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseDeveloperExceptionPage();

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                Authority = "http://localhost:5000",
                RequireHttpsMetadata = false,
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false
                }
            });

            app.UseOpenIddict();
            app.UseMvcWithDefaultRoute();
            app.UseWelcomePage();

            SeedDatabaseAsync(app).Wait();;
        }

        private static async Task SeedDatabaseAsync(IApplicationBuilder app)
        {
            var userManager = app.ApplicationServices.GetRequiredService<UserManager<ApplicationUser>>();

            if (!await userManager.Users.AnyAsync())
            {
                var adminUser = new ApplicationUser {UserName = "admin"};
                await userManager.CreateAsync(adminUser, "helloP4ss!");
            }
        }
    }
}
