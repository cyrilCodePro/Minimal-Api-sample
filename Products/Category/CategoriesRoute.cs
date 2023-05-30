using Application.Commands.Categories;
using Application.Queries;

using Domain.Entities;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Products
{
    public static class CategoriesRoute
    {
        public static RouteGroupBuilder AddCategoriesApi(this RouteGroupBuilder builder)

        {
            builder.MapPost("/", CreateCategory);
            builder.MapGet("/{id}", GetCategory);
            builder.MapGet("/", GetCategories);
            return builder;
        }
        public static async Task<Created>CreateCategory(AddCategory addCategory, ISender sender)
        {
          var result= await sender.Send(addCategory);

            return TypedResults.Created($"{result.Id}");
            
        }
        public static async Task<Ok<Category>> GetCategory(Guid id, ISender sender) 
            => TypedResults.Ok(await sender.Send(new GetCategory(new CategoryId(id))));
        public static async Task<Ok<List<Category>>> GetCategories(ISender sender)
            => TypedResults.Ok(await sender.Send(new GetCategories()));

    }
}
