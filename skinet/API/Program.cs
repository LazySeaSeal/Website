using API.Errors;
using API.Extensions;
using API.Middleware;
using Infrastructue.Data;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddpApplicationServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.(middlwares !!!!!!)
app.UseMiddleware<ExceptionMiddleware>();


app.UseStatusCodePagesWithReExecute("/errors/{0}");

// normaly there's an i f here to check if we're in dev mode or not , but we want swagger to be avlaible anyways
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();
/* this will automatically generate the migrations for us toul , so its an alternative way of executing migrations ali deja aamlnehum*/
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    await context.Database.MigrateAsync(); //this will excute migrations into the database , if the data base dosen't exist it will actually create it !
    await StoreContextSeed.SeedAsync(context); // for seeding the database
}
catch(Exception ex) 
{
    logger.LogError(ex,"an error occured during migrations");
}

app.Run();
