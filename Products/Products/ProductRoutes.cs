using Application.Commands.Categories;
using Application.Queries;

using MediatR;

using Microsoft.AspNetCore.Http.HttpResults;

namespace Products.Products
{
    public static class ProductRoutes
    {
        public static RouteGroupBuilder AddProductsApp(this RouteGroupBuilder builder)
        {

            builder.MapPost("/", CreateProduct);
            builder.MapGet("{id}", GetProduct);
            return builder;
        }

        public static async Task<Created> CreateProduct(AddProduct product,ISender sender)
        {
            var producttId=await sender.Send(product);

            return TypedResults.Created($"/{producttId.Id}");


        }
        public static async Task<Ok<Domain.Entities.Product>> GetProduct(Guid id,ISender sender)
        {
            var product=await sender.Send(new GetProduct(new Domain.Entities.ProductId(id)));

            return TypedResults.Ok(product);
        }
    }
}
