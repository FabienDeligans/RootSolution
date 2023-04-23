using Api.Logics;
using Api.Services;
using Library.Settings;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // R�cup�re les informations de la base de donn�es dans "appsettings.json"
            builder.Services.Configure<SettingsServiceMongoDb>(builder.Configuration.GetSection("MongoDatabase"));

            // Inscrit les couches Logic et Service dans l'injection de d�pendance
            builder.Services.AddTransient<ServiceDatabase>();
            builder.Services.AddTransient<FamilyLogic>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}