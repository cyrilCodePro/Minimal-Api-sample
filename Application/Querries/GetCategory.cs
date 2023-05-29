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
    public record GetCategory(CategoryId CategoryId): IRequest<Category?>;
    public class GetCategoryHandler : IRequestHandler<GetCategory, Category?>
    {
        private readonly ProductDbContext _productDbContext;

        public GetCategoryHandler(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public  async Task<Category?> Handle(GetCategory request, CancellationToken cancellationToken)
        {
            return await _productDbContext.Categories.FirstOrDefaultAsync(req => req.CategoryId == req.CategoryId, cancellationToken: cancellationToken);
        }
    }

}
