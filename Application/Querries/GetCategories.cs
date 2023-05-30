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
    public record GetCategories : IRequest<List<Category>>;
    public class GetCategoriesHandler : IRequestHandler<GetCategories, List<Category>>
    {
        private readonly ProductDbContext productDbContext;
        private readonly static Func<ProductDbContext ,IAsyncEnumerable<Category>> GetCategories=EF.CompileAsyncQuery((ProductDbContext productDbContext)=>productDbContext.Categories);

        public GetCategoriesHandler(ProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext;
        }

        public async Task<List<Category>> Handle(GetCategories request, CancellationToken cancellationToken)
        {
            List<Category> categories = new();
             await foreach(var item in GetCategories(productDbContext))
            {
                categories.Add(item);
            }
             return categories;
        }
    }
}


