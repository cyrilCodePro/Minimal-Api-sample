using Domain.Entities;

using Infrastructure;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public record GetCategory(CategoryId CategoryId): IRequest<Category?>;
    public class GetCategoryHandler : IRequestHandler<GetCategory, Category?>
    {
        private readonly ProductDbContext _productDbContext;
        private static readonly Func<ProductDbContext, GetCategory, IAsyncEnumerable<Category>> GetCategoryCompiledQuery =
            EF.CompileAsyncQuery((ProductDbContext context, GetCategory category) => from  s in context.Categories where s.CategoryId==category.CategoryId select s);
     

        public GetCategoryHandler(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public  async Task<Category?> Handle(GetCategory request, CancellationToken cancellationToken)
        {
            List<Category> categories = new();
             await foreach(var item in GetCategoryCompiledQuery(_productDbContext, request))
            {
                categories.Add(item);
            }
            return categories.SingleOrDefault();
        }
    }

}
