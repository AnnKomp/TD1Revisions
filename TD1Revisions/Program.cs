using TD1Revisions.Models.Repository;
using TD1Revisions.Models.DataManager;
using TD1Revisions.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Babylon.Blazor;


namespace TD1Revisions
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var MyAllowSpecificOrigins = "Project";

            var builder = WebApplication.CreateBuilder(args);

            //Add CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                        policy.WithOrigins("https://localhost:7169",
                                                         "https://localhost:7169/products",
                                                         "https://localhost:7169/adding",
                                                         "http://localhost:5266", 
                                                         "https://localhost:44359",
                                                         "http://localhost:61601")
                                        .AllowAnyHeader() 
                                        //.AllowAnyMethod();
                                        .WithMethods("GET", "POST", "PUT")
                                        .AllowCredentials();
                                  });
            });


            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ProduitsDBContext>( options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ProduitsDBContext")));

            //Data Repository
            builder.Services.AddScoped<IDataRepository<Marque>, MarqueManager>();
            builder.Services.AddScoped<IDataRepository<Produit>, ProduitManager>();
            builder.Services.AddScoped<IDataRepository<TypeProduit>, TypeProduitManager>();

            builder.Services.AddTransient<InstanceCreatorBase>(sp => new InstanceCreatorAsyncMode(sp.GetService<IJSRuntime>()));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();
            app.UseStaticFiles();


            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
    

}

