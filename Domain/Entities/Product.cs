using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public Product()
        {

        }
        public Product(ProductId productId, Price price, string name, string description)
        {
            ProductId = productId;
            Price = price;
            Name = name;
            Description = description;
        }

        public ProductId ProductId { get;  set; }
        public Price Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryId CategoryId { get; set; }
    }
    public record ProductId(Guid Id); 
    public record Price(string currency,decimal Value);
}
