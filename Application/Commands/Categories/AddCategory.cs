using Domain.Entities;

using Infrastructture;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Categories
{
   public record  AddCategory(string name): IRequest<CategoryId>;

    public class AddCategoryCommand : IRequestHandler<AddCategory, CategoryId>
    {
        private readonly ProductDbContext _productDbContext;

        public AddCategoryCommand(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public async Task<CategoryId> Handle(AddCategory request, CancellationToken cancellationToken)
        {
            var categoryId=new CategoryId(Guid.NewGuid());
          await  _productDbContext
                .Categories
                .AddAsync(
                     new Category(categoryId,request.name), 
                     cancellationToken
                     );
            await _productDbContext.SaveChangesAsync(cancellationToken);
            return categoryId;
        }
    }

}
