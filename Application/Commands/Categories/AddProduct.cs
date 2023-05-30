using Domain.Entities;

using Infrastructure;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Categories
{
    public record AddProduct(string ProdutName,Price Price, Guid CategoryId,string name,string description): IRequest<ProductId>;

    public class AddProductHandler : IRequestHandler<AddProduct, ProductId>
    {
        private readonly ProductDbContext productDbContext;

        public AddProductHandler(ProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext;
        }

        public async Task<ProductId> Handle(AddProduct request, CancellationToken cancellationToken)
        {
            var productId=new ProductId(Guid.NewGuid());
            await productDbContext.Products.AddAsync(new Product ( productId, request.Price,  new CategoryId(request.CategoryId), request.name,request.description)).ConfigureAwait(false);
            await productDbContext.SaveChangesAsync();
            return productId;
        }
    }


}
