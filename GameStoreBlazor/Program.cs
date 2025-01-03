using Blazored.FluentValidation;
using FluentValidation;
using GameStoreBlazor.Clients;
using GameStoreBlazor.Components;
using GameStoreBlazor.Models;


namespace GameStoreBlazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddValidatorsFromAssemblyContaining<GameDetailsValidator>();
            builder.Services.AddScoped<FluentValidationValidator>();
            builder.Services.AddSingleton<GamesClient>();
            builder.Services.AddSingleton<QrCodeService>();
            builder.Services.AddSingleton<PdfService>();
            builder.Services.AddServerSideBlazor(); 
            builder.Services.AddSignalR();




            var app = builder.Build();

            Directory.CreateDirectory(Path.Combine(app.Environment.WebRootPath, "pdf"));

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>();
            app.MapBlazorHub();
         

            app.Run();
        }
    }
}
