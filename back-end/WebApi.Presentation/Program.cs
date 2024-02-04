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
builder.Services.AddCustomControllers();

var app = builder.Build();

app.InitializeDatabase<ClientDBContext>();
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
