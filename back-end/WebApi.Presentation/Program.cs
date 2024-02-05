using DAL.DBContext;
using DAL.Extensions;
using BLL.Extensions;
using WebApi.Presentation.Extensions;
using WebApi.Presentation.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterDLLDependencies(config);
builder.Services.RegisterBLLDependencies(config);
builder.Services.AddSwaggerWithXmlComments();
builder.Services.ConfigureCors(config);
builder.Services.AddCustomControllers();
builder.Services.RegisterAutomapperProfiles();

var app = builder.Build();

app.UseCors();
app.InitializeDatabase<ClientDBContext>();
app.UseMiddleware<ExceptionMiddleware>();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
