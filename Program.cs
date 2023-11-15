using BackMicroservices.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

string stringConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AuctionDbContext>(opt => opt.UseMySql(stringConnection, ServerVersion.AutoDetect(stringConnection)));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try
{
    DbInitializer.InitDb(app);
}
catch (Exception e)
{
    Console.WriteLine(e);
}

app.Run();
