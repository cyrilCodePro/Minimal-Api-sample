using Domain.Entities;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Querries
{
   public record  GetAllProducts(CategoryId? CategoryId,string? searchTerm): IRequest<List<Product>>;
   
}
