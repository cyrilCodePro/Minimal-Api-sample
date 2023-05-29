using Infrastructure;

using Products;
using Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationService();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

var sampleTodos = TodoGenerator.GenerateTodos().ToArray();

//var todosApi = app.MapGroup("/todos");
//todosApi.MapGet("/", () => sampleTodos);
//todosApi.MapGet("/{id}", (int id) =>
//    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
//        ? Results.Ok(todo)
//        : Results.NotFound());
var category = app.MapGroup("categories").
    AddCategoriesApi()
    .WithTags("Product Categories");

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
    var pendingMigrations = ctx.Database.GetPendingMigrations();
    var migrator = ctx.GetInfrastructure().GetService<IMigrator>();
    foreach(var migration in pendingMigrations)
    {
        migrator?.Migrate(migration);
    }
}


app.Run();

