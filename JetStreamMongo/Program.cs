
using JetStreamMongo.Data;
using JetStreamMongo.Interfaces;

namespace JetStreamMongo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add services to the container.
            builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();

            builder.Services.AddScoped<MitarbeiterService>();

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
           
            Run(app.Services).Wait();
            
            app.Run();
        }

        public static async Task Run(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var dbContext = scopedServices.GetRequiredService<IMongoDbContext>();
            await dbContext.MitarbeiterSeedAsync();


        }
    }
}
