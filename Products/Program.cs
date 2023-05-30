using Infrastructure;

using Products;
using Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Products.Products;

var builder = WebApplication.CreateSlimBuilder(args);

//Register services
#region Service Registration
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationService();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();
#endregion

var app = builder.Build();
#region Api Registration

var category = app.MapGroup("categories").
    AddCategoriesApi()
    .WithTags("Product Categories");
var product = app.MapGroup("products")
    .AddProductsApp()
    .WithTags("Products ");
#endregion

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

