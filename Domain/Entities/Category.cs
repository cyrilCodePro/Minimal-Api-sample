using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        //For Entity Framework
        private Category() { }
        public CategoryId CategoryId { get; private set; }
        public string Name { get; private set; }
        public readonly HashSet<Product> Products = new();
        public void AddProducts(Product products)
        {
            Products.Add(products);
        }
        public Category(CategoryId categoryId,string name)
        {
            CategoryId = categoryId;
            Name = name;
        }
    }
    public record CategoryId(Guid Id);
    
}
