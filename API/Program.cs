using API.Configuration.Services;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAplicationServices(builder.Configuration);

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

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try {

   var context = services.GetRequiredService<DataContext>();
    context.Database.MigrateAsync();

} catch (Exception ex) {

	var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occrured during migration");

}

app.Run();
