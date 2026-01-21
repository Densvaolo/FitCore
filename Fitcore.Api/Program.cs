using FitCore.Application.Common.Interfaces;
using FitCore.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FitCoreDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IFitCoreDbContext>(provider =>
    provider.GetRequiredService<FitCoreDbContext>());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(
    typeof(FitCore.Application.Features.Users.Commands.CreateUser.CreateUserCommand).Assembly));



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
