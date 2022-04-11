using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//sonradan ekledim start
//builder.Configuration.AddJsonFile("appsettings.json", false, true);

//.net 5 versiyon için
//services.AddScoped<IDbConnection>(_ => 
//new SqlConnection(Configuration.GetConnectionString("BilProgApiConnection")));

//.net 6 versiyon için
builder.Services.AddScoped<IDbConnection>(_ => new SqlConnection(
    builder.Configuration.GetConnectionString("BilProgApiConnection")));


//sonradan ekledim end
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization(); 
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
