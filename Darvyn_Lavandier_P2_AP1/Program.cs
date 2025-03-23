using Darvyn_Lavandier_P2_AP1.Components;
using Darvyn_Lavandier_P2_AP1.Models;
using Microsoft.EntityFrameworkCore;
using Darvyn_Lavandier_P2_AP1.Services;


namespace Darvyn_Lavandier_P2_AP1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            //obtenemos el ConStr para usarlocon el contexto
            var ConSrt = builder.Configuration.GetConnectionString("SqlConStr");

            //Agregar contexto al builder con ConStr
            builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConSrt));

            // Add services to the container.
            builder.Services.AddScoped<CiudadServices>();
            builder.Services.AddScoped<EncuestaServices>();
            builder.Services.AddSignalR(); 


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

         

            app.Run();
        }
    }
}

