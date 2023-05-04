using Maletkunst.RestApi.DAL.DataAccess;
using Maletkunst.RestApi.DAL.Interface;

namespace Maletkunst.RestApi;

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

        builder.Services.AddScoped<IPaintingWinAppDataAccess, PaintingWinAppSqlDao>();
        builder.Services.AddScoped<IPaintingMvcDataAccess, PaintingMvcSqlDao>();
        builder.Services.AddScoped<IOrderMvcDataAccess, OrderMvcSqlDao>();
        //builder.Services.AddScoped<IOrderLineMvcDataAccess, OrderLineMvcSqlDao>();



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