using Blazor.Areas.Identity.Data;
using Blazor.Services;
using Library.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Blazor.Data;

namespace Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration
                .GetConnectionString("BlazorAuthContextConnection") ?? throw new InvalidOperationException("Connection string 'BlazorAuthContextConnection' not found.");

            builder.Services.AddDbContext<BlazorAuthContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddIdentity<User, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<BlazorAuthContext>()
                .AddDefaultTokenProviders();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            // R�cup�re la route principale de l'api dans "appsettings.json"
            builder.Services.Configure<SettingsCallApi>(builder.Configuration.GetSection("Api"));

            // Permet � FamilleCallApi d'apeller l'api
            builder.Services.AddHttpClient<FamilyCallApi>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            app.UseAuthentication(); ;

            app.Run();
        }
    }
}