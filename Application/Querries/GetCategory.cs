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
        private static readonly Func<ProductDbContext, GetCategory, Task<Category>> GetCategoryCompiledQuery =
            EF.CompileAsyncQuery((ProductDbContext context, GetCategory category) => context.Categories.SingleOrDefault(c => c.CategoryId == category.CategoryId));
     

        public GetCategoryHandler(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public  async Task<Category?> Handle(GetCategory request, CancellationToken cancellationToken)
        {
            return await GetCategoryCompiledQuery(_productDbContext, request);
        }
    }

}
