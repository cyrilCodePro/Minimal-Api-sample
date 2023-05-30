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
    public record GetProduct(ProductId ProductId): IRequest<Product>;
    public class GetProductHandler : IRequestHandler<GetProduct, Product>
    {
        private readonly ProductDbContext productDbContext;
        private static readonly Func<ProductDbContext,GetProduct,Task<Product>> GetProduct=EF.CompileAsyncQuery((ProductDbContext context,GetProduct Product) => context.Products.SingleOrDefault(i=>i.ProductId==Product.ProductId))

        public GetProductHandler(ProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext;
        }

        public async Task<Product> Handle(GetProduct request, CancellationToken cancellationToken)
        {
            return await GetProduct(productDbContext, request);
        }
    }
}
