using Microsoft.AspNetCore.Authentication.Cookies;
using RudeAnchorSN.LogicLayer.Services;
using RudeAnchorSN.LogicLayer.Utils;
using RudeAnchorSN.LogicLayer.Services.Logging.Extensions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RudeAnchorSN.Utils;
using RudeAnchorSN.Middleware;

namespace RudeAnchorSN
{
    public class Program
    {
        private static IConfiguration Configuration { get; } =
            new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json")
            .Build();

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connection = Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddSingleton<IFriendService, FriendService>();
            builder.Services.AddSingleton<IRequestService, RequestService>();
            builder.Services.AddSingleton<IUserPostService, UserPostService>();
            builder.Services.AddSingleton<IChatService, ChatService>();

            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => 
                {
                    options.LoginPath = new PathString("/");
                });

            builder.Services.AddExceptionHandler<CustomExceptionHandler>();

            builder.Logging.AddFileLogger();

            var app = builder.Build();


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");

                app.UseHsts();
            }

            app.UseMiddleware<LoggingMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
