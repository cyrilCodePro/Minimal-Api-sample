using Domain.Entities;

using Infrastructture;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Querries
{
    public record GetCategories : IRequest<List<Category>>;
    public class GetCategoriesHandler : IRequestHandler<GetCategories, List<Category>>
    {
        private readonly ProductDbContext productDbContext;

        public GetCategoriesHandler(ProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext;
        }

        public Task<List<Category>> Handle(GetCategories request, CancellationToken cancellationToken)
        {
            return productDbContext.Categories.ToListAsync(cancellationToken);
        }
    }
}


